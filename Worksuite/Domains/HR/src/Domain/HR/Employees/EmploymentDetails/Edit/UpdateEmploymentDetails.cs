using Content.Services.HR.Messages;
using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit
{
    public class UpdateEmploymentDetails
                    : IUpdateEmploymentDetails
    {
        public UpdateEmploymentDetailsResponse execute
                                                (UpdateEmploymentDetailsRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .find_employee()
                    .check_has_permission_to_update_employment_details()
                    .sanitise_request()
                    .load_reference_data()
                    .validate_request()
                    .update_employment_details()
                    .commit()
                    .publish_employment_details_updated_event()
                    .build_response()
                    ;
        }

        private UpdateEmploymentDetails set_request
                                            (UpdateEmploymentDetailsRequest the_request)
        {
            Guard.IsNotNull(the_request, "the_request");

            request = the_request;
            response_builder = new ResponseBuilder<UpdateEmploymentDetailsResponse>();
            return this;
        }

        private UpdateEmploymentDetails find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = employee_repository
                .Entities
                .Single(e => e.id == request.employee_id)
                ;

            return this;
        }

        private UpdateEmploymentDetails check_has_permission_to_update_employment_details()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!can_update_employment_details.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.default_update_permission_not_granted);
            }
            return this;
        }

        private UpdateEmploymentDetails sanitise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request = new UpdateEmploymentDetailsRequest
            {
                employee_id = request.employee_id,
                employeeReference = request.employeeReference.normalise_for_persistence(),
                job_title_id = request.job_title_id,
                location_id = request.location_id
            };
            return this;
        }

        private UpdateEmploymentDetails load_reference_data()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            reference_data = new ReferenceData
            {
                job_title = job_title_repository
                                .Entities
                                .SingleOrDefault(t => t.id == request.job_title_id),

                location = location_repository
                                .Entities
                                .SingleOrDefault(l => l.id == request.location_id)
            };

            return this;
        }

        private UpdateEmploymentDetails validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(reference_data, "reference_data");

            // check whether there are any employees that have the same employee request
            var other_employee_with_same_reference_exist = employee_repository
                                                            .Entities
                                                            .Where(e => e.employeeReference.Equals(request.employeeReference, StringComparison.InvariantCultureIgnoreCase))
                                                            .Any(e => e.id != request.employee_id)  // ignore the employee we are updating
                                                            ;

            validator.field("employeeReference")
                .is_madatory(request.employeeReference, ValidationMessages.error_00_0023)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.employeeReference, ValidationMessages.error_01_0001)
                .premise_holds(!other_employee_with_same_reference_exist, ValidationMessages.error_00_0024)
                ;

            validator
                .field("job_title_id")
                .premise_holds(has_not_been_changed(employee.job_title, reference_data.job_title) || is_not_hidden(reference_data.job_title), "Please select a job title that is not hidden")
                ;

            validator
                .field("location_id")
                .premise_holds(has_not_been_changed(employee.location, reference_data.location) || is_not_hidden(reference_data.location), "Please select a location that is not hidden")
                ;

            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private UpdateEmploymentDetails update_employment_details()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(request, "request");

            employee.employeeReference = request.employeeReference;
            employee.job_title = reference_data.job_title;
            employee.location = reference_data.location;

            return this;
        }

        private UpdateEmploymentDetails commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private UpdateEmploymentDetails publish_employment_details_updated_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            employee_event_publisher.publish(new EmployeeEmploymentDetailsUpdatedEvent
            {
                employee_id = employee.id,
                employee_reference = employee.employeeReference,
                job_title_id = employee.job_title.get_id_or_default_if_null(),
                job_title_description = employee.job_title.get_description_or_default_if_null(),
                location_id = employee.location.get_id_or_default_if_null(),
                location_description = employee.location.get_description_or_default_if_null()
            });
            return this;
        }

        private UpdateEmploymentDetailsResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.confirmation_04_0001);
            }
            return response_builder.build();
        }

        private bool has_not_been_changed<T>
                                (T source, T destination)
                        where T : ReferenceDataModel
        {
            return source == destination;
        }

        private bool is_not_hidden
                        (ReferenceDataModel entry_to_check)
        {
            return entry_to_check == null || !entry_to_check.is_hidden;
        }

        public UpdateEmploymentDetails
                (IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_employee_repository
                , Validator the_validator
                , ICanUpdateEmploymentDetails can_update_employee_details_permission
                , IEntityRepository<JobTitle> the_job_title_repository
                , IEntityRepository<Location> the_location_repository
                , IEventPublisher<EmployeeEmploymentDetailsUpdatedEvent> the_employee_event_publisher)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "theUnitOfWork");
            employee_repository = Guard.IsNotNull(the_employee_repository, "theEmployeeRepository");
            validator = Guard.IsNotNull(the_validator, "theValidator");
            can_update_employment_details = Guard.IsNotNull(can_update_employee_details_permission, "can_update_employee_details_permission");
            job_title_repository = Guard.IsNotNull(the_job_title_repository, "the_job_title_repository");
            location_repository = Guard.IsNotNull(the_location_repository, "the_location_repository");
            employee_event_publisher = Guard.IsNotNull(the_employee_event_publisher, "the_employee_event_publisher");
        }

        private readonly ICanUpdateEmploymentDetails can_update_employment_details;
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly Validator validator;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<JobTitle> job_title_repository;
        private readonly IEntityRepository<Location> location_repository;
        private readonly IEventPublisher<EmployeeEmploymentDetailsUpdatedEvent> employee_event_publisher;

        private UpdateEmploymentDetailsRequest request;
        private ResponseBuilder<UpdateEmploymentDetailsResponse> response_builder;
        private Employee employee;
        private ReferenceData reference_data;

        private class ReferenceData
        {
            public JobTitle job_title;
            public Location location;
        }
    }
}
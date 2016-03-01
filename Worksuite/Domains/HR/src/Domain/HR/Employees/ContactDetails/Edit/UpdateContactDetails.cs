using System.Linq;
using Content.Services.HR.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit
{
    public class UpdateContactDetails : IUpdate
    {
        public UpdateResponse execute(UpdateRequest the_request)
        {
            return this
                .set_request(the_request)
                .authorise()
                .sanatise_request()
                .validate_request()
                .load_employee()
                .update_employee_contact_details()
                .commit()
                .publish_contact_details_updated_event()
                .build_response()
                ;
        }

        private UpdateContactDetails set_request(UpdateRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<EmployeeIdentity, UpdateResponse>();
            response_builder.set_response(new EmployeeIdentity { employee_id = Null.Id });

            return this;
        }

        private UpdateContactDetails authorise()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.default_update_permission_not_granted);
            }

            return this;
        }

        private UpdateContactDetails sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request = new UpdateRequest
            {
                employee_id = request.employee_id,
                phone = request.phone.normalise_for_persistence(),
                email = request.email.normalise_for_persistence(),
                mobile = request.mobile.normalise_for_persistence(),
                other = request.other.normalise_for_persistence()
            };

            return this;
        }

        private UpdateContactDetails validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            validator.field("phone")
                     .does_not_contains_characters_that_are_invalid_in_a_phone_field(request.phone, ValidationMessages.error_00_0010)
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.phone, ValidationMessages.error_01_0001)
                     ;

            validator.field("mobile")
                     .does_not_contains_characters_that_are_invalid_in_a_mobile_field(request.mobile, ValidationMessages.error_00_0010)
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.mobile, ValidationMessages.error_01_0001)
                     ;

            validator.field("email")
                     .does_not_exceed_the_maximum_number_of_characters_for_email(request.email, ValidationMessages.max_number_of_characters_in_text_field_exceeded_email);

            validator.field("email")
                     .does_not_start_or_end_with_at_sign_in_email(request.email, ValidationMessages.email_cannot_start_or_end_with_at_sign);

            validator.field("email")
                     .does_not_start_or_end_with_dot_in_email(request.email, ValidationMessages.email_cannot_start_or_end_with_dot);

            validator.field("email")
                     .email_requires_at_least_one_character_followed_by_at_sign_then_followed_by_at_least_one_character_then_followed_by_dot_then_followed_by_at_least_one_character
                        (request.email
                        , ValidationMessages.email_field_does_not_meet_pattern);

            validator.field("other")
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.other, ValidationMessages.error_01_0001);

            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }

            return this;
        }

        private UpdateContactDetails load_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;

            if (employee == null)
            {
                response_builder.add_error(ValidationMessages.warning_03_0018);
            }

            return this;
        }

        private UpdateContactDetails update_employee_contact_details()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");

            employee.phone_number = request.phone;
            employee.email = request.email != null ? request.email.ToLower() : null;
            employee.mobile = request.mobile;
            employee.other = request.other;

            return this;
        }

        private UpdateContactDetails commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private UpdateContactDetails publish_contact_details_updated_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            event_publisher.publish(new EmployeeContactDetailsUpdatedEvent
                                        {
                                            employee_id = employee.id,
                                            phone_number = employee.phone_number,
                                            email = employee.email,
                                            mobile = employee.mobile,
                                            other = employee.other
                                        });

            return this;
        }

        private UpdateResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.update_was_successfull);
                response_builder.set_response(request);
            }
            return response_builder.build();
        }

        public UpdateContactDetails(IUnitOfWork the_unit_of_work,
                                      IEntityRepository<Employee> the_repository,
                                      Validator the_validator,
                                      ICanUpdateContactDetails the_execute_permission,
                                      IEventPublisher<EmployeeContactDetailsUpdatedEvent> the_event_publisher
                                    )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> repository;
        private readonly Validator validator;
        private readonly ICanUpdateContactDetails execute_permission;

        private UpdateRequest request;
        private ResponseBuilder<EmployeeIdentity, UpdateResponse> response_builder;
        private Employee employee;
        private readonly IEventPublisher<EmployeeContactDetailsUpdatedEvent> event_publisher;
    }
}
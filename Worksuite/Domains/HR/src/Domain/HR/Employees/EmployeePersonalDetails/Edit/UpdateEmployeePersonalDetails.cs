using System;
using System.Linq;
using Content.Services.HR.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit
{
    public class UpdateEmployeePersonalDetails
        : IUpdateEmployeePersonalDetails
    {
        public UpdateEmployeePersonalDetailsResponse execute
            (UpdateEmployeePersonalDetailsRequest the_request)
        {
            return 
                 set_request(the_request)
                .authorise()
                .sanatise_request()
                .load_employee()
                .load_reference_data()
                .validate_request()
                .update_employee()
                .commit()
                .publish_personal_details_updated_event()
                .build_response()
                ;
        }

        private UpdateEmployeePersonalDetails set_request
            (UpdateEmployeePersonalDetailsRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            response_builder = new ResponseBuilder<UpdateEmployeePersonalDetailsResponse>();
            return this;
        }

        private UpdateEmployeePersonalDetails authorise()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.default_update_permission_not_granted);
            }
            return this;
        }

        private UpdateEmployeePersonalDetails sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            gregorian_calendar_sanitisation.execute(request.date_of_birth)
                .Match(
                    is_valid:
                        valid_date_of_birth =>
                        {
                            request.date_of_birth.year = valid_date_of_birth.year.ToString();
                            request.date_of_birth.month = valid_date_of_birth.month.ToString();
                            request.date_of_birth.day = valid_date_of_birth.day.ToString();
                        },
                    is_not_valid:
                        error =>
                        {
                            if (error == null) return;
                            response_builder.add_error(
                            ValidationMessages.error_050320151200.ToResponseMessage("date_of_birth"));
                            response_builder.add_error("error".ToResponseMessage("date_of_birth.year"));
                            response_builder.add_error("error".ToResponseMessage("date_of_birth.month"));
                            response_builder.add_error("error".ToResponseMessage("date_of_birth.day"));
                        });

            request = new UpdateEmployeePersonalDetailsRequest
            {
                // Improve: use normalise for persistence
                // Improve: sort out the naming of the field
                employee_id = request.employee_id,
                forename = request.forename.normalise_for_persistence(),
                surname = request.surname.normalise_for_persistence(),
                othername = request.othername.normalise_for_persistence(),
                birth_place = request.birth_place.normalise_for_persistence(),
                date_of_birth = request.date_of_birth,
                title_id = request.title_id,
                gender_id = request.gender_id,
                marital_status_id = request.marital_status_id,
                nationality_id = request.nationality_id,
                ethnic_origin_id = request.ethnic_origin_id,
            };
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private UpdateEmployeePersonalDetails load_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = employee_repository
                .Entities
                .FirstOrDefault(e => e.id == request.employee_id)
                ;

            if (employee == null)
            {
                response_builder.add_error(ValidationMessages.warning_03_0018);
            }
            return this;
        }

        private UpdateEmployeePersonalDetails load_reference_data()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            reference_data = new ReferenceData
            {
                title = title_repository
                    .Entities
                    .SingleOrDefault(t => t.id == request.title_id),

                gender = gender_repository
                    .Entities
                    .SingleOrDefault(g => g.id == request.gender_id),

                marital_status = marital_status_repository
                    .Entities
                    .SingleOrDefault(g => g.id == request.marital_status_id),

                nationality = nationality_repository
                    .Entities
                    .SingleOrDefault(n => n.id == request.nationality_id),

                ethnic_origin = ethnic_origin_repository
                    .Entities
                    .SingleOrDefault(eo => eo.id == request.ethnic_origin_id),
            };
            return this;
        }

        private UpdateEmployeePersonalDetails validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(reference_data, "reference_data");

            // forename
            validator
                .field("forename")
                .is_madatory(request.forename, ValidationMessages.error_01_0004)
                .does_not_contains_characters_that_are_invalid_in_a_persons_name(request.forename,
                    ValidationMessages.persons_name_has_invalid_characters)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.forename,
                    ValidationMessages.error_01_0001)
                ;

            // surname
            validator
                .field("surname")
                .is_madatory(request.surname, ValidationMessages.error_01_0005)
                .does_not_contains_characters_that_are_invalid_in_a_persons_name(request.surname,
                    ValidationMessages.persons_name_has_invalid_characters)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.surname,
                    ValidationMessages.error_01_0001)
                ;

            // othername
            validator
                .field("othername")
                .does_not_contains_characters_that_are_invalid_in_a_persons_name(request.othername,
                    ValidationMessages.persons_name_has_invalid_characters)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.othername,
                    ValidationMessages.error_01_0001)
                ;

            // birth_place
            validator
                .field("birth_place")
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.birth_place,
                    ValidationMessages.error_01_0001)
                ;

            // dateofbirth validation

            var date_time = string.IsNullOrWhiteSpace(request.date_of_birth.year)
                            && string.IsNullOrWhiteSpace(request.date_of_birth.month)
                            && string.IsNullOrWhiteSpace(request.date_of_birth.day)
                            ? (DateTime?) null
                            : request.date_of_birth.to_date_time();
                if (date_time > DateTime.Now)
                {
                    response_builder.add_error(ValidationMessages.error_060320151023.ToResponseMessage ("date_of_birth"));
                    response_builder.add_error("error".ToResponseMessage("date_of_birth.year"));
                    response_builder.add_error("error".ToResponseMessage("date_of_birth.month"));
                    response_builder.add_error("error".ToResponseMessage("date_of_birth.day"));
                }

            // title
            validator
                .field("title_id")
                // Improve: .premise_holds( entry_was_found(request.title_id, reference_data.title),  )
                .premise_holds(
                    has_not_been_changed(employee.title, reference_data.title) || is_not_hidden(reference_data.title),
                    "Please select a title that is not hidden")
                ;

            // gender
            validator
                .field("gender_id")
                .premise_holds(
                    has_not_been_changed(employee.gender, reference_data.gender) || is_not_hidden(reference_data.gender),
                    "Please select a gender that is not hidden")
                ;

            // marital status
            validator
                .field("marital_status_id")
                .premise_holds(
                    has_not_been_changed(employee.maritalStatus, reference_data.marital_status) ||
                    is_not_hidden(reference_data.marital_status), "Please select a marital status that is not hidden")
                ;

            // nationality
            validator
                .field("nationality_id")
                .premise_holds(
                    has_not_been_changed(employee.nationality, reference_data.nationality) ||
                    is_not_hidden(reference_data.nationality), "Please select a nationality that is not hidden")
                ;

            // ethnic origin
            validator
                .field("ethnic_origin_id")
                .premise_holds(
                    has_not_been_changed(employee.ethnicOrigin, reference_data.ethnic_origin) ||
                    is_not_hidden(reference_data.ethnic_origin), "Please select a nationality that is not hidden")
                ;

            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private UpdateEmployeePersonalDetails update_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(reference_data, "reference_data");

            employee.forename = request.forename;
            employee.surname = request.surname;
            employee.title = reference_data.title;
            employee.gender = reference_data.gender;
            employee.maritalStatus = reference_data.marital_status;
            employee.nationality = reference_data.nationality;
            employee.ethnicOrigin = reference_data.ethnic_origin;
            employee.othername = request.othername;
            employee.birth_place = request.birth_place;
            employee.dateofbirth = string.IsNullOrWhiteSpace(request.date_of_birth.year)
                                   && string.IsNullOrWhiteSpace(request.date_of_birth.month)
                                   && string.IsNullOrWhiteSpace(request.date_of_birth.day)
                                   ? (DateTime?) null
                                   : request.date_of_birth.to_date_time();
            return this;
        }

        private UpdateEmployeePersonalDetails commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private UpdateEmployeePersonalDetails publish_personal_details_updated_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            event_publisher.publish(new EmployeePersonalDetailsUpdatedEvent
            {
                employee_id = employee.id,
                forename = employee.forename,
                surname = employee.surname,
                othername = employee.othername,
                place_of_birth = employee.birth_place,
                date_of_birth = employee.dateofbirth,
                title_id = employee.title.get_id_or_default_if_null(),
                title_description = employee.title.get_description_or_default_if_null(),
                gender_id = employee.gender.get_id_or_default_if_null(),
                gender_description = employee.gender.get_description_or_default_if_null(),
                marital_status_id = employee.maritalStatus.get_id_or_default_if_null(),
                marital_status_description = employee.maritalStatus.get_description_or_default_if_null(),
                nationality_id = employee.nationality.get_id_or_default_if_null(),
                nationality_description = employee.nationality.get_description_or_default_if_null(),
                ethnic_origin_id = employee.ethnicOrigin.get_id_or_default_if_null(),
                ethnic_origin_description = employee.ethnicOrigin.get_description_or_default_if_null()
            });
            return this;
        }

        private UpdateEmployeePersonalDetailsResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.update_was_successfull);
            }
          
            return response_builder.build();
        }

        public UpdateEmployeePersonalDetails
            (IUnitOfWork the_unit_of_work
                , IEntityRepository<Employee> the_repository
                , IEntityRepository<Title> the_title_repository
                , IEntityRepository<Gender> the_gender_repository
                , IEntityRepository<MaritalStatus> the_marital_status_repository
                , IEntityRepository<Nationality> the_nationality_repository
                , IEntityRepository<EthnicOrigin> the_ethnic_origin_repository
                , Validator the_validator
                , ICanUpdatePersonalDetails the_execute_permission
                , IEventPublisher<EmployeePersonalDetailsUpdatedEvent> the_event_publisher
               )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            title_repository = Guard.IsNotNull(the_title_repository, "the_title_repository");
            gender_repository = Guard.IsNotNull(the_gender_repository, "the_gender_repository");
            marital_status_repository = Guard.IsNotNull(the_marital_status_repository, "the_maritalStatus_repository");
            nationality_repository = Guard.IsNotNull(the_nationality_repository, "the_nationality_repository");
            ethnic_origin_repository = Guard.IsNotNull(the_ethnic_origin_repository, "the_ethnic_origin_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
            gregorian_calendar_sanitisation = new GregorianCalendarSanitisation(new MonthInferenceSanitisation());
        }

        private bool has_not_been_changed<T>(T source, T destination) where T : ReferenceDataModel
        {
            return source == destination;
        }

        // check to see if a reference data entry has been set to hidden (nulls are treat as not hidden).
        private bool is_not_hidden(ReferenceDataModel entry_to_check)
        {
            return entry_to_check == null || !entry_to_check.is_hidden;
        }

        private UpdateEmployeePersonalDetailsRequest request;
        private Employee employee;
        private ReferenceData reference_data;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly Validator validator;
        private readonly ICanUpdatePersonalDetails execute_permission;
        private readonly IEntityRepository<Title> title_repository;
        private readonly IEntityRepository<Gender> gender_repository;
        private readonly IEntityRepository<MaritalStatus> marital_status_repository;
        private readonly IEntityRepository<Nationality> nationality_repository;
        private readonly IEntityRepository<EthnicOrigin> ethnic_origin_repository;
        private readonly GregorianCalendarSanitisation gregorian_calendar_sanitisation;
        private readonly IEventPublisher<EmployeePersonalDetailsUpdatedEvent> event_publisher;
        private ResponseBuilder<UpdateEmployeePersonalDetailsResponse> response_builder =
            new ResponseBuilder<UpdateEmployeePersonalDetailsResponse>();
        private class ReferenceData
        {
            public Title title;
            public Gender gender;
            public MaritalStatus marital_status;
            public Nationality nationality;
            public EthnicOrigin ethnic_origin;
        }
    }

}
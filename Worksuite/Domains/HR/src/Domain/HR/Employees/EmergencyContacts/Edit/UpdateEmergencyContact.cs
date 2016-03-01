using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit
{
    public class UpdateEmergencyContact : IUpdate
    {
        public UpdateEmergencyContact ( IUnitOfWork the_unit_of_work
                        , IEntityRepository<Employee> the_repository
                        , IEntityRepository<Relationship> the_relationship_repository
                        , Validator the_validator
                        , ICanUpdateEmergencyContact the_execute_permission
                        , IEventPublisher<EmployeeEmergencyContactDetailsUpdateEvent> the_event_publisher)
        {
            Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            Guard.IsNotNull(the_repository, "the_repository");
            Guard.IsNotNull(the_validator, "the_validator");
            Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            
            unit_of_work = the_unit_of_work;
            repository = the_repository;
            validator = the_validator;
            execute_permission = the_execute_permission;
            
            event_publisher=Guard.IsNotNull(the_event_publisher,"the_event_publisher");
            relationship_repository = Guard.IsNotNull(the_relationship_repository, "the_relationship_repository");
            
        }

        public UpdateResponse execute(UpdateRequest request)
        {

            initialise_response_builder(request);
            can_the_emergency_contact_be_updated();


            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);

                return response_builder.build();
            }

            get_employee();
            get_emergency_contact_that_needs_to_be_updated();

            validate_emergency_contact_details_to_be_updated();

            validate_relationship();



            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
                return response_builder.build();
            }

            apply_changes();
            publish_emergency_contact_details_update_event();

            response_builder.add_message(ValidationMessages.confirmation_04_0001);

            // - report the status
            response_builder.set_response(request);
            return response_builder.build();
        }

        private void initialise_response_builder(UpdateRequest request)
        {
            update_request = Guard.IsNotNull(request, "update_request");
            response_builder.set_response(new EmergencyContactIdentity { emergency_contact_id = Null.Id, employee_id = Null.Id });
        }

        private void can_the_emergency_contact_be_updated()
        {
            validator
              .premise_holds(execute_permission.IsGrantedFor(update_request)
                            , ValidationMessages.default_update_permission_not_granted);

            response_builder.add_errors(validator.errors);

        }

        private void get_employee()
        {
            employee = repository
                               .Entities
                               .Single(e => e.id == update_request.employee_id)
                               ;
        }

        private void get_emergency_contact_that_needs_to_be_updated()
        {
            emergency_contact = employee.EmergencyContacts.Single(a => a.id == update_request.emergency_contact_id);
        }

        private void validate_relationship()
        {
            relationship = relationship_repository
                            .Entities
                            .SingleOrDefault(r => r.id == update_request.relationship_id && !r.is_hidden)
                            ;

            if (relationship == null && update_request.relationship_id > 0)
            {
                validator.field("relationship_id")
                .premise_holds(relationship != null, "Please select a relationship that is not hidden")
                ;
            }
        }

        private void validate_emergency_contact_details_to_be_updated()
        {
            validator.field("name")
                    .is_madatory(update_request.name, ValidationMessages.error_01_0021)
                    .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( update_request.name, ValidationMessages.error_01_0001 )
                    ;

            validator.field( "primary_phone_number" )
                    .is_madatory( update_request.primary_phone_number, ValidationMessages.error_01_0022 )
                    .does_not_contains_characters_that_are_invalid_in_a_phone_field( update_request.primary_phone_number, ValidationMessages.error_00_0010 )
                    .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( update_request.primary_phone_number, ValidationMessages.error_01_0001 )
                    ;

            validator.field( "other_phone_number" )
                    .does_not_contains_characters_that_are_invalid_in_a_phone_field( update_request.other_phone_number, ValidationMessages.error_00_0010 )
                    .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( update_request.other_phone_number, ValidationMessages.error_01_0001 )
                    ;
        }

        private UpdateEmergencyContact publish_emergency_contact_details_update_event()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(emergency_contact, "emergency_contact");

            event_publisher.publish(new EmployeeEmergencyContactDetailsUpdateEvent()
                                   {
                                       employee_id = employee.id,
                                       emergency_contact_id = emergency_contact.id,
                                       name = emergency_contact.name,
                                       relationship_id = emergency_contact.relationship.get_id_or_default_if_null(),
                                       primary_phone_number = emergency_contact.primary_phone_number,
                                       other_phone_number = emergency_contact.other_phone_number,
                                       priority = emergency_contact.priority
                                   });
            return this;
        }

        private void apply_changes()
        {
            emergency_contact.name = update_request.name.Trim();
            emergency_contact.primary_phone_number = update_request.primary_phone_number.Trim();
            emergency_contact.other_phone_number = update_request.other_phone_number == null || update_request.other_phone_number.Trim().Equals("") ? null : update_request.other_phone_number.Trim();
            emergency_contact.relationship = relationship;
            unit_of_work.Commit();
        }

        private Employee employee;
        private Relationship relationship;
        private readonly Validator validator;
        private UpdateRequest update_request;
        private readonly IUnitOfWork unit_of_work;
        private EmergencyContact emergency_contact;
        private readonly IEntityRepository<Employee> repository;
        private readonly IEntityRepository<Relationship> relationship_repository;
        private readonly ICanUpdateEmergencyContact execute_permission;
        private readonly IEventPublisher<EmployeeEmergencyContactDetailsUpdateEvent> event_publisher;
        private readonly ResponseBuilder<EmergencyContactIdentity, UpdateResponse> response_builder = new ResponseBuilder<EmergencyContactIdentity, UpdateResponse>();

    }
}
using System.Collections.Generic;
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
using WTS.WorkSuite.Library.DomainTypes.OrderList;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public class NewEmergencyContact : INewEmergencyContact
    {
        public NewEmergencyContact(IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> the_event_publisher_emergecy_contact_auto_reordered
                                  ,IEventPublisher<EmployeeEmergencyContactDetailsCreateEvent> the_event_publisher_emergency_contact
                                  , INewEmergencyContactValidator the_new_emergency_contact_validator
                                  , IEntityRepository<Relationship> the_relationship_repository
                                  , ICanAddNewEmergencyContact the_execute_permission
                                  ,IEntityRepository<Employee> the_repository
                                  , IUnitOfWork the_unit_of_work
                                  , Validator the_validator)
        {
                    repository = Guard.IsNotNull(the_repository, "the_repository");
                    relationship_repository = Guard.IsNotNull(the_relationship_repository, "the_relationship_repository");
                    unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
                    execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
                    new_emergency_contact_validator = Guard.IsNotNull(the_new_emergency_contact_validator, "the_new_emergency_contact_validator");
                    validator = Guard.IsNotNull(the_validator, "the_validator");
                    event_publisher_emergency_contact = Guard.IsNotNull(the_event_publisher_emergency_contact,"the_event_publisher_emergency_contact");
                   event_publisher_emergecy_contact_auto_reordered = Guard.IsNotNull(the_event_publisher_emergecy_contact_auto_reordered,
                    "the_event_publisher_emergecy_contact_auto_reordered");
        }

        public NewEmergencyContactResponse execute( NewEmergencyContactRequest the_request )
        {
            return this
                .set_request(the_request)
                .authorize()
                .find_employee()
                .validate_request()
                .create_emergency_contact()
                .commit()
                .publish_emergency_contact_details_create_event()
                .publish_emergency_contact_auto_reordered_events()
                .build_response()
                ;
        }

        private NewEmergencyContact set_request(NewEmergencyContactRequest the_request)
        {
            Guard.IsNotNull( the_request, "the_request" );

            request = the_request;

            response_builder.set_response( 
                                        new EmergencyContactIdentity
                                                {   employee_id = request.employee_id,
                                                    emergency_contact_id = Null.Id
                                                }
                                         );
            return this;
        }

        private NewEmergencyContact authorize()
        {
            if ( response_builder.has_errors ) return this;

            if ( !execute_permission.IsGrantedFor( request ) )
            {
                response_builder.add_error( ValidationMessages.warning_03_0001 );
            }
            return this;
        }

        private NewEmergencyContact find_employee()
        {
            if ( response_builder.has_errors ) return this;

            employee = repository
                            .Entities
                            .Single( e => e.id == request.employee_id )
                            ;
            return this;
        }

        private NewEmergencyContact validate_request()
        {
            if (response_builder.has_errors) return this;

            var validation_errors = new_emergency_contact_validator.validateEmergencyContact(request);
            if (validation_errors.Any())
            {
                response_builder.add_errors(validation_errors);
            }

            relationship = relationship_repository
                            .Entities
                            .SingleOrDefault(r => r.id == request.relationship_id && !r.is_hidden)
                            ;

            if (relationship == null && request.relationship_id > 0)
            {
                validator.field("relationship_id")
                .premise_holds(relationship != null, "Please select a relationship that is not hidden")
                ;
            }

            var more_errors = validator.errors;
            if (more_errors.Any())
            {
                response_builder.add_errors(more_errors);
            }

            return this;

        }

        private NewEmergencyContact create_emergency_contact()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");

            // create the emergency contact, new emergency contacts are always set as the primary emergency contact
            new_emergency_contact = new EmergencyContact
            {
                name = request.name == null || request.name.Trim().Equals("") ? null : request.name.Trim(),
                primary_phone_number = request.primary_phone_number == null || request.primary_phone_number.Trim().Equals("") ? null : request.primary_phone_number.Trim(),
                other_phone_number = request.other_phone_number == null || request.other_phone_number.Trim().Equals("") ? null : request.other_phone_number.Trim(),
                relationship = relationship,
                priority = 1
            };

            var index_entry_mapper = new ListEntryIndexMapper<EmergencyContact>
                                                    (em => em.priority,
                                                        (em, value) => em.priority = value
                                                    );

            employee
                .EmergencyContacts
                .Select(index_entry_mapper.map)
                .Insert(index_entry_mapper.map(new_emergency_contact),
                            () => employee.EmergencyContacts.Add(new_emergency_contact)
                       )
                ;
            return this;
        }

        private NewEmergencyContact commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private NewEmergencyContact publish_emergency_contact_details_create_event()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(new_emergency_contact, "new_emergency_contact");

            event_publisher_emergency_contact.publish(new EmployeeEmergencyContactDetailsCreateEvent()
            {
                employee_id = employee.id,
                emergency_contact_id = new_emergency_contact.id,
                name = new_emergency_contact.name,
                relationship_id = new_emergency_contact.relationship.get_id_or_default_if_null(),
                primary_phone_number = new_emergency_contact.primary_phone_number,
                other_phone_number = new_emergency_contact.other_phone_number,
                priority = new_emergency_contact.priority
            });
            return this;
        }

        private NewEmergencyContact publish_emergency_contact_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmergencyContacts, "employee.EmergencyContacts");
            Guard.IsNotNull(new_emergency_contact, "new_emergency_contact");

            foreach (EmergencyContact emergency_contact in employee.EmergencyContacts)
            {

                if (emergency_contact.id == new_emergency_contact.id) continue;
                
                    event_publisher_emergecy_contact_auto_reordered.publish(new EmployeeEmergencyContactAutoReorderedEvent()
                                           { 

                                               employee_id = employee.id,
                                               emergency_contact_id = emergency_contact.id,
                                               name = emergency_contact.name,
                                               relationship_id = emergency_contact.relationship.get_id_or_default_if_null(),
                                               primary_phone_number = emergency_contact.primary_phone_number,
                                               other_phone_number = emergency_contact.other_phone_number,
                                               priority = emergency_contact.priority
                                               
                                           });
            }


            return this;

        }

        private NewEmergencyContactResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                var confirmation = new List<string> { ValidationMessages.confirmation_04_0001 };
                response_builder.add_messages(confirmation);
                response_builder.set_response(new EmergencyContactIdentity { employee_id = request.employee_id, emergency_contact_id = new_emergency_contact.id });
            }
            else
            {
                response_builder.add_errors(new List<string> {
                    ValidationMessages.warning_03_0001,
                });
            }
            return response_builder.build();
        }

        private readonly ICanAddNewEmergencyContact execute_permission;
        private readonly IEntityRepository<Employee> repository;
        private readonly IEntityRepository<Relationship> relationship_repository;
        private readonly IUnitOfWork unit_of_work;
        private EmergencyContact new_emergency_contact;
        private Employee employee;
        private Relationship relationship;
        private NewEmergencyContactRequest request;
        private readonly INewEmergencyContactValidator new_emergency_contact_validator;
        private readonly Validator validator;
        private readonly ResponseBuilder<EmergencyContactIdentity, NewEmergencyContactResponse> response_builder = new ResponseBuilder<EmergencyContactIdentity, NewEmergencyContactResponse>();
        private readonly IEventPublisher<EmployeeEmergencyContactDetailsCreateEvent> event_publisher_emergency_contact;
        private readonly IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher_emergecy_contact_auto_reordered;
    }
}
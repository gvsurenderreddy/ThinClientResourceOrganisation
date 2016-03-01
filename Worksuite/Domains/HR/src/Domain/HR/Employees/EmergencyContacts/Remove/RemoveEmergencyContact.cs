using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.OrderList;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Remove
{
    public class RemoveEmergencyContact : IRemoveEmergencyContact
    {
        public RemoveEmergencyContact(  IUnitOfWork the_unit_of_work,
                                        IEntityRepository<Employee> the_employee_repository,
                                        IEventPublisher<EmployeeEmergencyContactDetailsRemoveEvent> the_event_publisher_emergency_contact_removed,
                                        IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> the_event_publisher_emergency_contact_auto_reordered )
        {
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher_emergency_contact_auto_reordered = Guard.IsNotNull(the_event_publisher_emergency_contact_auto_reordered, "the_event_publisher_emergency_contact_auto_reordered");
            event_publisher_emergency_contact_removed = Guard.IsNotNull(the_event_publisher_emergency_contact_removed,"the_event_publisher_emergency_contact_removed");
        }

        public RemoveEmergencyContactResponse execute( EmergencyContactIdentity request )
        {
            return this
                .set_request(request)
                .find_employee()
                .find_emergency_contact()
                .create_employee_emergency_contact_removed_event()
                .identify_the_priority_of_the_address_to_be_removed()
                .remove_emergency_contact()
                .commit()
                .publish_emergency_contact_removed_event()
                .publish_address_auto_reordered_events()
                .build_response()
                ;
        }

        private RemoveEmergencyContact set_request( EmergencyContactIdentity the_request )
        {
            request = Guard.IsNotNull( the_request, "the_remove_emergency_contact_request" );

            response_builder.set_response(
                                        new EmergencyContactIdentity
                                        {
                                            employee_id = Null.Id,
                                            emergency_contact_id = Null.Id
                                        }
                                         );

            return this;
        }

        private RemoveEmergencyContact find_employee()
        {
            if ( response_builder.has_errors ) return this;

            employee = employee_repository
                            .Entities
                            .Single( e => e.id == request.employee_id );
            return this;
        }

        private RemoveEmergencyContact find_emergency_contact()
        {
            if ( response_builder.has_errors ) return this;
            if ( employee == null ) return this;

            Guard.IsNotNull( employee, "employee" );
            Guard.IsNotNull( employee.EmergencyContacts, "employee.EmergencyContact" );

            emergency_contact = employee
                                    .EmergencyContacts
                                    .Single( a => a.id == request.emergency_contact_id );
            return this;
        }

        private RemoveEmergencyContact create_employee_emergency_contact_removed_event()
        {
            if (response_builder.has_errors) return this;
            if (emergency_contact == null) return this;
            Guard.IsNotNull(emergency_contact, "emergency_contact");

            emergency_contact_remove_event =new EmployeeEmergencyContactDetailsRemoveEvent()
                                            {
                                                employee_id = employee.id,
                                                emergency_contact_id = emergency_contact.id,
                                                name = emergency_contact.name,
                                                relationship_id = emergency_contact.relationship.get_id_or_default_if_null(),
                                                primary_phone_number = emergency_contact.primary_phone_number,
                                                other_phone_number = emergency_contact.other_phone_number,
                                                priority = emergency_contact.priority
                                            };
            return this;
        }

        private RemoveEmergencyContact identify_the_priority_of_the_address_to_be_removed()
        {
            if (response_builder.has_errors) return this;
            if (emergency_contact == null) return this;

            Guard.IsNotNull(emergency_contact, "emergency_contact");
            priority_of_the_emergency_contact_to_be_removed = emergency_contact.priority;
            return this;
        }

        private RemoveEmergencyContact remove_emergency_contact()
        {
            if ( response_builder.has_errors ) return this;
            if ( emergency_contact == null ) return this;

            Guard.IsNotNull( emergency_contact, "emergency_contact" );

            var index_entry_mapper = new ListEntryIndexMapper< EmergencyContact >
                                                    (   a => a.priority,
                                                        ( a, value ) => a.priority = value
                                                    );
            employee
                .EmergencyContacts
                .Select( index_entry_mapper.map )
                .Remove(    index_entry_mapper.map( emergency_contact ),
                            () =>
                                {
                                    employee.EmergencyContacts.Remove( emergency_contact );
                                    employee_repository.remove( emergency_contact );
                                }
                       );
            return this;
        }

        private RemoveEmergencyContact commit()
        {
            if ( response_builder.has_errors ) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveEmergencyContact publish_emergency_contact_removed_event()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(emergency_contact, "emergency_contact");
            Guard.IsNotNull(employee, "employee");

            event_publisher_emergency_contact_removed
                                      .publish(emergency_contact_remove_event);
            return this;
        }

        private RemoveEmergencyContact publish_address_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(emergency_contact, "emergency_contact");
            Guard.IsNotNull(employee.EmergencyContacts, "employee.EmergencyContacts");
            Guard.IsNotNull(priority_of_the_emergency_contact_to_be_removed,"priority_of_the_emergency_contact_to_be_removed");

            foreach (EmergencyContact otherEmergencyContact in employee.EmergencyContacts)
            {
             
                if(otherEmergencyContact.priority < priority_of_the_emergency_contact_to_be_removed) continue;

                event_publisher_emergency_contact_auto_reordered.publish(new EmployeeEmergencyContactAutoReorderedEvent()
                                               {
                                                   employee_id = employee.id,
                                                   emergency_contact_id = otherEmergencyContact.id,
                                                   name = otherEmergencyContact.name,
                                                   primary_phone_number = otherEmergencyContact.primary_phone_number,
                                                   other_phone_number = otherEmergencyContact.other_phone_number,
                                                   priority = otherEmergencyContact.priority
                                               });
   
            }
            return this;
        }

        private RemoveEmergencyContactResponse build_response()
        {
            if ( !response_builder.has_errors )
            {
                response_builder.add_message( ValidationMessages.remove_was_successfull );
            }

            return response_builder.build();
        }

        private Employee employee;
        private EmergencyContactIdentity request;
        private readonly IUnitOfWork unit_of_work;
        private EmergencyContact emergency_contact;
        private int priority_of_the_emergency_contact_to_be_removed;
        private readonly IEntityRepository<Employee> employee_repository;
        private EmployeeEmergencyContactDetailsRemoveEvent emergency_contact_remove_event;
        private readonly IEventPublisher<EmployeeEmergencyContactDetailsRemoveEvent> event_publisher_emergency_contact_removed;
        private readonly IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher_emergency_contact_auto_reordered;
        private readonly ResponseBuilder< EmergencyContactIdentity, RemoveEmergencyContactResponse > response_builder =new ResponseBuilder< EmergencyContactIdentity, RemoveEmergencyContactResponse >();


    }
}
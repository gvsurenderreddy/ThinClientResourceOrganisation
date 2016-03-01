using System.Linq;
using Content.Services.Common.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.OrderList;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public class ReorderEmergencyContact : IReorderEmergencyContact
    {
        public ReorderEmergencyContact(  IEventPublisher<EmployeeEmergencyContactManualReorderedEvent> the_event_publisher_Emergency_contcat_manual_reordered
                                       , IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> the_event_publisher_Emergency_contcat_auto_reordered
                                       , IEntityRepository<Employee> the_employee_repository
                                       , Validator the_validator
                                       , IUnitOfWork the_unit_of_work
                                       , ICanReorderEmergencyContact the_execute_permission
                                      )
        {
            _unitOfWork         = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            _employeeRepository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            _validator          = Guard.IsNotNull( the_validator, "the_validator" );
            _executePermission  = Guard.IsNotNull( the_execute_permission, "the_execute_permission" );
            event_publisher_Emergency_contcat_manual_reordered =Guard.IsNotNull(the_event_publisher_Emergency_contcat_manual_reordered,"the_event_publisher_Emergency_contcat_manual_reordered");
            event_publisher_Emergency_contcat_auto_reordered = Guard.IsNotNull(the_event_publisher_Emergency_contcat_auto_reordered, " the_event_publisher_Emergency_contcat_auto_reordered");
        }

        public ReorderEmergencyContactResponse execute(ReorderEmergencyContactRequest request)
        {
            return this
                .set_request( request )
                .authorize()
                .find_employee()
                .find_emergency_contact()
                .get_a_copy_of_all_emergency_contact()
                .create_emergency_contact_move_request()
                .validate()
                .move_emergency_contact()
                .commit()
                .publish_emergency_contact_manual_reordered_event()
                .publish_emergency_contact_auto_reordered_events()
                .build_response()
                ;
        }

        private ReorderEmergencyContact set_request(ReorderEmergencyContactRequest request)
        {
            _reorderEmergencyContactRequest = Guard.IsNotNull(request, "reorder_emergency_contact_request");
            return this;
        }

        private ReorderEmergencyContact authorize()
        {
            if (_responseBuilder.has_errors) return this;

            if ( !_executePermission.IsGrantedFor( _reorderEmergencyContactRequest ) )
            {
                _responseBuilder.add_error( ValidationMessages.default_reorder_permission_not_granted );
            }
            return this;
        }

        private ReorderEmergencyContact find_employee()
        {
            if ( _responseBuilder.has_errors ) return this;

            _employee = _employeeRepository
                            .Entities
                            .Single( e => e.id == _reorderEmergencyContactRequest.employee_id );
            return this;
        }

        private ReorderEmergencyContact find_emergency_contact()
        {
            if ( _responseBuilder.has_errors ) return this;
            if (_employee == null) return this;

            Guard.IsNotNull(_employee, "_employee");

            _emergencyContact = _employee
                                    .EmergencyContacts
                                    .Single( ec => ec.id == _reorderEmergencyContactRequest.emergency_contact_id );
            return this;
        }

        private ReorderEmergencyContact get_a_copy_of_all_emergency_contact()
        {
            if (_responseBuilder.has_errors) return this;
            if (_employee == null) return this;
            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee.EmergencyContacts, "_employee.EmergencyContacts");

            cached_emergency_contact=new EmergencyContactPriority[_employee.EmergencyContacts.Count];
            int count = 0;
            foreach (EmergencyContact otherEmergencyContact in _employee.EmergencyContacts)
            {
                cached_emergency_contact[count] =new EmergencyContactPriority(){emergency_contact_id = otherEmergencyContact.id ,priority = otherEmergencyContact.priority};
                count ++;
            }

            cached_emergency_contact.OrderBy(e => e.priority);
            return this;
        }

        private ReorderEmergencyContact create_emergency_contact_move_request()
        {
            if ( _responseBuilder.has_errors ) return this;
            if ( _emergencyContact == null ) return this;

            Guard.IsNotNull(_emergencyContact, "_emergencyContact");

            _moveRequest = new MoveIndexEntryRequest
            {
                @from    = _emergencyContact.priority,
                to      = _reorderEmergencyContactRequest.priority
            };
            return this;
        }

        private ReorderEmergencyContact validate()
        {
            if ( _responseBuilder.has_errors ) return this;

            _validator
                .field("priority")
                .premise_holds(_moveRequest.to >= 1, ValidationMessages.error_03_0007)
                .premise_holds(_moveRequest.to <= _employee.EmergencyContacts.Count(),
                    ValidationMessages.error_03_0008)
                ;
            _responseBuilder.add_errors( _validator.errors );
            return this;
        }

        private ReorderEmergencyContact move_emergency_contact()
        {
            if ( _responseBuilder.has_errors ) return this;

            Guard.IsNotNull( _moveRequest, "_moveRequest" );

            var to_index_mapper = new ListEntryIndexMapper<EmergencyContact>
                                            (   m => m.priority,
                                                ( m, value ) => m.priority = value
                                            );
            _employee
                .EmergencyContacts
                .Select( to_index_mapper.map )
                .Move( _moveRequest )
                ;
            return this;
        }

        private ReorderEmergencyContact commit()
        {
            if ( _responseBuilder.has_errors ) return this;

            _unitOfWork.Commit();
            return this;
        }

        private ReorderEmergencyContact publish_emergency_contact_manual_reordered_event()
        {
            if (_responseBuilder.has_errors) return this;
            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_emergencyContact, "_emergencyContact");

            event_publisher_Emergency_contcat_manual_reordered.publish(new EmployeeEmergencyContactManualReorderedEvent()
            {
                employee_id = _employee.id,
                emergency_contact_id = _emergencyContact.id,
                name = _emergencyContact.name,
                relationship_id = _emergencyContact.relationship.get_id_or_default_if_null(),
                primary_phone_number = _emergencyContact.primary_phone_number,
                other_phone_number = _emergencyContact.other_phone_number,
                priority = _emergencyContact.priority
            });

            return this;
        }
        private ReorderEmergencyContact publish_emergency_contact_auto_reordered_events()
        {
            if (_responseBuilder.has_errors) return this;

            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee.Address, "_employee.Address");
            Guard.IsNotNull(_emergencyContact, "_emergencyContact");
            Guard.IsNotNull(cached_emergency_contact, "cached_emergency_contact");

            foreach (EmergencyContactPriority otheremergencyContact in cached_emergency_contact)
            {
                if (_moveRequest.from == _moveRequest.to) break; // re-ordered to the same position, therefore no need to raise any auto reordered events.

                if (otheremergencyContact.emergency_contact_id == _emergencyContact.id) continue; // a manual reordered event has been raised already for the address re-ordered.

                var the_emergency_content = _employee.EmergencyContacts.Single(a => a.id == otheremergencyContact.emergency_contact_id); // Get the updated copy of the address.

                if (otheremergencyContact.priority == the_emergency_content.priority) continue; // if there is no priority change made for the address, there is no need to trigger an auto reordered event.

                event_publisher_Emergency_contcat_auto_reordered.publish(new EmployeeEmergencyContactAutoReorderedEvent
                {
                  employee_id = _employee.id,
                  emergency_contact_id = the_emergency_content.id,
                  name = the_emergency_content.name,
                  relationship_id = the_emergency_content.relationship.get_id_or_default_if_null(),
                  primary_phone_number = the_emergency_content.primary_phone_number,
                  other_phone_number = the_emergency_content.other_phone_number,
                  priority = the_emergency_content.priority
                }
                                                         );
            }

            return this;
        }

        private ReorderEmergencyContactResponse build_response()
        {
            if ( !_responseBuilder.has_errors )
            {
                _responseBuilder.add_message(
                            ValidationMessages.reorder_was_successfull( _moveRequest.from,
                                                                        _moveRequest.to
                                                                      )
                                            );
            }

            return _responseBuilder.build();
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly Validator _validator;
        private readonly ICanReorderEmergencyContact _executePermission;
        private readonly ResponseBuilder<ReorderEmergencyContactResponse> _responseBuilder = new ResponseBuilder<ReorderEmergencyContactResponse>();
        private readonly IEventPublisher<EmployeeEmergencyContactManualReorderedEvent> event_publisher_Emergency_contcat_manual_reordered;
        private readonly IEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher_Emergency_contcat_auto_reordered;
        private ReorderEmergencyContactRequest _reorderEmergencyContactRequest;
        private Employee _employee;
        private EmergencyContact _emergencyContact;
        private MoveIndexEntryRequest _moveRequest;
        private EmergencyContactPriority[] cached_emergency_contact;
    }
   
    public class EmergencyContactPriority
    {
        public int emergency_contact_id { get; set; }

        public int priority { get; set; }
    }
}
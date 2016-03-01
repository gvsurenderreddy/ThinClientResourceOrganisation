using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.EmergencyContact
{
    public class AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated
                               : IEventSubscriber<EmployeeEmergencyContactDetailsUpdateEvent>
    {
        public void  handle(EmployeeEmergencyContactDetailsUpdateEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_emergency_details_update_audit_record()
                .commit();
        }


        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated set_event
                                                                                  (EmployeeEmergencyContactDetailsUpdateEvent the_event_to_handle)
        {
            event_to_handler = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            recieved_at = clock.now();
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated get_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handler, "event_to_handler");
            Guard.IsNotNull(recieved_at, "recieved_at");
            Guard.IsNotNull(get_or_create_employee_audit_record, "get_or_create_employee_audit_record");

            var request = new GetOrCreateEmployeeAuditTrailRequest(employee_id: event_to_handler.employee_id,
                                                                   received_at: recieved_at);
            audit_trail = get_or_create_employee_audit_record.execute(request);
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated add_employee_audit_record()
        {
            Guard.IsNotNull(employee_audit_record_builder, "employee_audit_record_builder");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(recieved_at, "recieved_at");
            var audit_record = employee_audit_record_builder
                              .build(new NewEmployeeAuditRecordRequest(received_at: recieved_at));

            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated add_emergency_details_update_audit_record()
        {
            Guard.IsNotNull(emergency_contact_audit_record_builder, "emergency_contact_audit_record_builder");
            Guard.IsNotNull(event_to_handler, "event_to_handler");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(recieved_at, "recieved_at");

            var audit_record = emergency_contact_audit_record_builder
                              .build(new NewEmergencyContactAtailsAuditModelRequest( emergency_contact_id: event_to_handler.emergency_contact_id
                                                                                   , name:event_to_handler.name
                                                                                   , relationship_id:event_to_handler.relationship_id
                                                                                   , priority:event_to_handler.priority
                                                                                   ,primary_phone_number:event_to_handler.primary_phone_number,
                                                                                   other_phone_number:event_to_handler.other_phone_number
                                                                                   , received_at: recieved_at));
                
             audit_trail.emergency_contact_details_audit.Add(audit_record);
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated( GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsUpdateEvent> the_get_or_create_employee_audit_record
                                                                                 , EmployeeAuditRecordBuilder<EmployeeEmergencyContactDetailsUpdateEvent> the_employee_audit_record_builder
                                                                                 , EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactDetailsUpdateEvent> the_emergency_contact_audit_record_builder
                                                                                 , IUnitOfWork the_unit_of_work
                                                                                 , Clock the_clock)
        {
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder,"the_employee_audit_record_builder");
            get_or_create_employee_audit_record = Guard.IsNotNull(the_get_or_create_employee_audit_record,"the_get_or_create_employee_audit_record");
            emergency_contact_audit_record_builder = Guard.IsNotNull(the_emergency_contact_audit_record_builder,"the_emergency_contact_audit_record_builder");
        }

        private readonly Clock clock;
        private UtcTime recieved_at;
        private EmployeeAuditTrail audit_trail;
        private readonly IUnitOfWork unit_of_work;
        private EmployeeEmergencyContactDetailsUpdateEvent event_to_handler;
        private readonly EmployeeAuditRecordBuilder<EmployeeEmergencyContactDetailsUpdateEvent> employee_audit_record_builder; 
        private readonly GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsUpdateEvent> get_or_create_employee_audit_record;
        private readonly EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactDetailsUpdateEvent> emergency_contact_audit_record_builder;
        
    }
}
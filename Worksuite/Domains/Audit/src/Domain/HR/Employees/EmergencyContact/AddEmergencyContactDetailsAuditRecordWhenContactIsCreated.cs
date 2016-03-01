using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.EmergencyContact
{
    public class AddEmergencyContactDetailsAuditRecordWhenContactIsCreated
                                        : IEventSubscriber<EmployeeEmergencyContactDetailsCreateEvent>
    {
        public void handle
                        (EmployeeEmergencyContactDetailsCreateEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_emergency_contact_details_created_audit_record()
                .commit();
        }

        private AddEmergencyContactDetailsAuditRecordWhenContactIsCreated set_event
                                                                 ( EmployeeEmergencyContactDetailsCreateEvent the_event_to_handle )
        {
            event_to_handel = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            received_at = clock.now();
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenContactIsCreated get_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(received_at, "received_at");
            Guard.IsNotNull(get_or_create_emergency_employee_audit_trail, "get_or_create_emergency_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest(
                              employee_id: event_to_handel.employee_id , 
                              received_at: received_at
                );

            audit_trail = get_or_create_emergency_employee_audit_trail.execute(request);
            return this;
        }


        private AddEmergencyContactDetailsAuditRecordWhenContactIsCreated add_employee_audit_record()
        {
            Guard.IsNotNull(employee_audit_record_builder, "employee_audit_record_builder");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employee_audit_record_builder
                                     .build(new NewEmployeeAuditRecordRequest(received_at: received_at));                     
            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenContactIsCreated add_emergency_contact_details_created_audit_record()
        {
            Guard.IsNotNull(emergency_contact_details_audit_record_builder, "emergency_contact_details_audit_record_builder");
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = emergency_contact_details_audit_record_builder
                                  .build(new NewEmergencyContactAtailsAuditModelRequest(
                                               emergency_contact_id: event_to_handel.emergency_contact_id,
                                               name: event_to_handel.name,
                                               relationship_id:event_to_handel.relationship_id,
                                               primary_phone_number:event_to_handel.primary_phone_number,
                                               other_phone_number:event_to_handel.other_phone_number,
                                               priority:event_to_handel.priority,
                                               received_at:received_at
                                        ));
            audit_trail.emergency_contact_details_audit.Add(audit_record);
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public AddEmergencyContactDetailsAuditRecordWhenContactIsCreated
                                                                 ( EmployeeAuditRecordBuilder < EmployeeEmergencyContactDetailsCreateEvent > the_emergency_contact_record_builder,
                                                                   GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsCreateEvent> the_get_or_create_emergency_employee_audit_trail,
                                                                   EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactDetailsCreateEvent> the_emergency_contact_details_audit_record_builder,
                                                                   IUnitOfWork the_unit_of_work,
                                                                   Clock the_clock )
        {
            employee_audit_record_builder = Guard.IsNotNull(the_emergency_contact_record_builder,"the_emergency_contact_record_builder");
            get_or_create_emergency_employee_audit_trail =Guard.IsNotNull(the_get_or_create_emergency_employee_audit_trail,"the_get_or_create_emergency_employee_audit_trail");
            emergency_contact_details_audit_record_builder =Guard.IsNotNull(the_emergency_contact_details_audit_record_builder,"the_emergency_contact_details_audit_record_builder");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            clock = Guard.IsNotNull(the_clock, "the_clock");
        }

        private UtcTime received_at;
        private readonly Clock clock;
        private EmployeeAuditTrail audit_trail;
        private readonly IUnitOfWork unit_of_work;
        private EmployeeEmergencyContactDetailsCreateEvent event_to_handel;
        private readonly EmployeeAuditRecordBuilder<EmployeeEmergencyContactDetailsCreateEvent> employee_audit_record_builder;
        private readonly GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsCreateEvent> get_or_create_emergency_employee_audit_trail;
        private readonly EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactDetailsCreateEvent> emergency_contact_details_audit_record_builder; 
        
    }
}
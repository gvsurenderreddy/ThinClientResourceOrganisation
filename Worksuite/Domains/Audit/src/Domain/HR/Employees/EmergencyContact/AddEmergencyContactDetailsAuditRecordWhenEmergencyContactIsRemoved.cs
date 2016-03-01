using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.EmergencyContact
{
    public class AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved
                                         : IEventSubscriber<EmployeeEmergencyContactDetailsRemoveEvent>
    {
        public void handle(EmployeeEmergencyContactDetailsRemoveEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_emergency_contact_details_removed_audit_record()
                .commit();
            
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved set_event
                                                                               (EmployeeEmergencyContactDetailsRemoveEvent the_event_to_handle)
        {
            event_to_handel = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            recieved_at = clock.now();
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved get_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(get_or_remove_emergency_audit_trail, "get_or_remove_emergency_audit_trail");
            Guard.IsNotNull(recieved_at, "recieved_at");

            var request = new GetOrCreateEmployeeAuditTrailRequest(employee_id: event_to_handel.employee_id
                                                                  , received_at: recieved_at);

            audit_trail = get_or_remove_emergency_audit_trail.execute(request);
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved add_employee_audit_record()
        {
            Guard.IsNotNull(employee_audit_record_builder, "employee_audit_record_builder");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(recieved_at, "recieved_at");

            var audit_record = employee_audit_record_builder
                                          .build(new NewEmployeeAuditRecordRequest(received_at: recieved_at));

            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved add_emergency_contact_details_removed_audit_record()
        {
            Guard.IsNotNull(employee_emergency_contact_audit_record_builder,"employee_emergency_contact_audit_record_builder");
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(recieved_at, "recieved_at");

            var audit_record = employee_emergency_contact_audit_record_builder
                              .build( new NewEmergencyContactAtailsAuditModelRequest(
                                           emergency_contact_id: event_to_handel.emergency_contact_id,
                                           name:event_to_handel.name,
                                           relationship_id:event_to_handel.relationship_id,
                                           priority:event_to_handel.priority,
                                           primary_phone_number:event_to_handel.primary_phone_number,
                                           other_phone_number:event_to_handel.other_phone_number,
                                           received_at:recieved_at)
                                      );
            audit_trail.emergency_contact_details_audit.Add(audit_record);
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved ( EmergencyContactDetailsAuditRecordBuilder < EmployeeEmergencyContactDetailsRemoveEvent > the_employee_emergency_contact_audit_record_builder,
                                                                                    GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsRemoveEvent> the_get_or_remove_emergency_audit_trail,
                                                                                    EmployeeAuditRecordBuilder<EmployeeEmergencyContactDetailsRemoveEvent> the_employee_audit_record_builder,
                                                                                    IUnitOfWork the_unit_of_work,
                                                                                    Clock the_clock
                                                                                  )
        {

            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder,"the_employee_audit_record_builder");
            get_or_remove_emergency_audit_trail = Guard.IsNotNull(the_get_or_remove_emergency_audit_trail,"the_get_or_remove_emergency_audit_trail");
            employee_emergency_contact_audit_record_builder =Guard.IsNotNull(the_employee_emergency_contact_audit_record_builder,"the_employee_emergency_contact_audit_record_builder");
        }

        private UtcTime recieved_at;
        private readonly Clock clock;
        private EmployeeAuditTrail audit_trail;
        private readonly IUnitOfWork unit_of_work;
        private EmployeeEmergencyContactDetailsRemoveEvent event_to_handel;
        private readonly EmployeeAuditRecordBuilder < EmployeeEmergencyContactDetailsRemoveEvent > employee_audit_record_builder;
        private readonly GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactDetailsRemoveEvent> get_or_remove_emergency_audit_trail;
        private readonly EmergencyContactDetailsAuditRecordBuilder < EmployeeEmergencyContactDetailsRemoveEvent > employee_emergency_contact_audit_record_builder;
    }
}
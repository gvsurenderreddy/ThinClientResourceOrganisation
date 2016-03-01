using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.EmergencyContact
{
    public class AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered <T> 
                                           : IEventSubscriber<T>
                                   where T : EmployeeEmergencyContactReorderedEvent
    {
        public void handle(T the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_address_reordered_audit_record()
                .commit()
                ;

        }

        private AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered<T> set_event(T the_event_to_handle)
        {
            event_to_handel = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            received_at = clock.now();
            return this;
        }

        private AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered<T> get_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(received_at, "received_at");
            Guard.IsNotNull(get_or_create_employee_audit_trail, "get_or_create_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest
                                                ( employee_id: event_to_handel.employee_id,
                                                  received_at: received_at
                                                );
            audit_trail = get_or_create_employee_audit_trail.execute(request);
            return this;
        }

        private AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered<T> add_employee_audit_record()
        {
            Guard.IsNotNull(employee_audit_record_builder, "employee_audit_record_builder");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employee_audit_record_builder
                              .build(new NewEmployeeAuditRecordRequest(received_at: received_at));

            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered<T> add_address_reordered_audit_record()
        {
            Guard.IsNotNull(emergency_contact_Details_audit_record_builder, "emergency_contact_Details_audit_record_builder");
            Guard.IsNotNull(event_to_handel, "event_to_handel");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = emergency_contact_Details_audit_record_builder
                              .build(new NewEmergencyContactAtailsAuditModelRequest(
                                         emergency_contact_id:event_to_handel.emergency_contact_id,
                                         name:event_to_handel.name,
                                         relationship_id:event_to_handel.relationship_id,
                                         priority:event_to_handel.priority,
                                         primary_phone_number:event_to_handel.primary_phone_number,
                                         other_phone_number:event_to_handel.other_phone_number,
                                         received_at:received_at
                                    ));
            audit_trail.emergency_contact_details_audit.Add(audit_record);
            return this;
        }

        private void commit()
        {
            unite_of_work.Commit();
        }

        public AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered( EmergencyContactDetailsAuditRecordBuilder<T> the_emergency_contact_Details_audit_record_builder
                                                                            , GetOrCreateEmployeeAuditTrail<T> the_get_or_create_employee_audit_trail
                                                                            , EmployeeAuditRecordBuilder<T> the_employee_audit_record_builder
                                                                            , IUnitOfWork the_unite_of_work
                                                                            , Clock the_clock
                                                                            )
        {
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unite_of_work = Guard.IsNotNull(the_unite_of_work, "the_unite_of_work");
            employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder, "the_employee_audit_record_builder");
            get_or_create_employee_audit_trail = Guard.IsNotNull(the_get_or_create_employee_audit_trail, "the_get_or_create_employee_audit_trail");
            emergency_contact_Details_audit_record_builder =Guard.IsNotNull(the_emergency_contact_Details_audit_record_builder,"the_emergency_contact_Details_audit_record_builder");
        }

        private T event_to_handel;
        private UtcTime received_at;
        private readonly Clock clock;
        private EmployeeAuditTrail audit_trail;
        private readonly IUnitOfWork unite_of_work;
        private readonly EmployeeAuditRecordBuilder<T> employee_audit_record_builder;
        private readonly GetOrCreateEmployeeAuditTrail<T> get_or_create_employee_audit_trail;
        private readonly EmergencyContactDetailsAuditRecordBuilder<T> emergency_contact_Details_audit_record_builder;
    }

    public class AddEmergencyContactAuditRecordWhenEmergencyContactIsManuallyReordered
                        : AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered <EmployeeEmergencyContactManualReorderedEvent>
         
    {
        public AddEmergencyContactAuditRecordWhenEmergencyContactIsManuallyReordered( EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactManualReorderedEvent> the_emergency_contact_Details_audit_record_builder
                                                                                    , GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactManualReorderedEvent> the_get_or_create_employee_audit_trail
                                                                                    , EmployeeAuditRecordBuilder<EmployeeEmergencyContactManualReorderedEvent> the_employee_audit_record_builder
                                                                                    , IUnitOfWork the_unite_of_work, Clock the_clock) 

                         : base( the_emergency_contact_Details_audit_record_builder
                               , the_get_or_create_employee_audit_trail
                               , the_employee_audit_record_builder
                               , the_unite_of_work, the_clock) { }
    }

    public class AddEmergencyContactAuditRecordWhenEmergencyContactIsAutomaticallyReordered
                        : AddEmergencyContactAuditRecordWhenEmergencyConatctIsReordered<EmployeeEmergencyContactAutoReorderedEvent>
    {
        public AddEmergencyContactAuditRecordWhenEmergencyContactIsAutomaticallyReordered( EmergencyContactDetailsAuditRecordBuilder<EmployeeEmergencyContactAutoReorderedEvent> the_emergency_contact_Details_audit_record_builder
                                                                                         , GetOrCreateEmployeeAuditTrail<EmployeeEmergencyContactAutoReorderedEvent> the_get_or_create_employee_audit_trail
                                                                                         , EmployeeAuditRecordBuilder<EmployeeEmergencyContactAutoReorderedEvent> the_employee_audit_record_builder
                                                                                         , IUnitOfWork the_unite_of_work, Clock the_clock) 
                      
                        : base( the_emergency_contact_Details_audit_record_builder
                              , the_get_or_create_employee_audit_trail
                              , the_employee_audit_record_builder
                              , the_unite_of_work, the_clock) { }
    }
}
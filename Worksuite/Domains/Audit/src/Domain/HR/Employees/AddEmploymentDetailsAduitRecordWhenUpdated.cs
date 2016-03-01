using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class AddEmploymentDetailsAduitRecordWhenUpdated
                    : IEventSubscriber<EmployeeEmploymentDetailsUpdatedEvent>
    {
        public void handle
                        (EmployeeEmploymentDetailsUpdatedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .update_employee_audit_trail()
                .add_employee_audit_record()
                .add_employment_details_updated_audit_record()
                .commit()
                ;
        }

        public AddEmploymentDetailsAduitRecordWhenUpdated
                    (GetOrCreateEmployeeAuditTrail<EmployeeEmploymentDetailsUpdatedEvent> get_or_create_employee_audit_trail_command
                    , EmployeeEmploymentDetailsAuditRecordBuilder<EmployeeEmploymentDetailsUpdatedEvent> the_employment_details_audit_redord_builder
                    , EmployeeAuditRecordBuilder<EmployeeEmploymentDetailsUpdatedEvent> the_employee_audit_record_builder
                    , Clock the_clock
                    , IUnitOfWork the_unit_of_work)
        {
            get_or_create_employee_audit_trail = Guard.IsNotNull(get_or_create_employee_audit_trail_command, "get_or_create_employee_audit_trail_command");
            employment_details_audit_redord_builder = Guard.IsNotNull(the_employment_details_audit_redord_builder, "the_employment_details_audit_redord_builder");
            employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder, "the_employee_audit_record_builder");
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private AddEmploymentDetailsAduitRecordWhenUpdated set_event
                                                            (EmployeeEmploymentDetailsUpdatedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            received_at = clock.now();
            return this;
        }

        private AddEmploymentDetailsAduitRecordWhenUpdated get_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(received_at, "received_at");

            var request = new GetOrCreateEmployeeAuditTrailRequest(
                employee_id: event_to_handle.employee_id,
                received_at: received_at
            );

            audit_trail = get_or_create_employee_audit_trail.execute(request);
            return this;
        }

        private AddEmploymentDetailsAduitRecordWhenUpdated update_employee_audit_trail()
        {
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(event_to_handle, "event_to_handle");

            audit_trail.employee_reference = event_to_handle.employee_reference.normalise_for_persistence();
            return this;
        }

        private AddEmploymentDetailsAduitRecordWhenUpdated add_employee_audit_record()
        {
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employee_audit_record_builder.build(new NewEmployeeAuditRecordRequest(
                received_at: received_at
            ));

            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddEmploymentDetailsAduitRecordWhenUpdated add_employment_details_updated_audit_record()
        {
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employment_details_audit_redord_builder.build(new NewEmployeeEmploymentDetailsAuditModelRequest(
                employee_reference: event_to_handle.employee_reference,
                job_title_id: event_to_handle.job_title_id,
                job_title_description: event_to_handle.job_title_description,
                location_id: event_to_handle.location_id,
                location_description: event_to_handle.location_description,
                received_at: received_at
            ));

            audit_trail
                .employment_details_audit
                .Add(audit_record);

            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        private readonly GetOrCreateEmployeeAuditTrail<EmployeeEmploymentDetailsUpdatedEvent> get_or_create_employee_audit_trail;
        private readonly EmployeeEmploymentDetailsAuditRecordBuilder<EmployeeEmploymentDetailsUpdatedEvent> employment_details_audit_redord_builder;
        private readonly EmployeeAuditRecordBuilder<EmployeeEmploymentDetailsUpdatedEvent> employee_audit_record_builder;
        private readonly Clock clock;
        private readonly IUnitOfWork unit_of_work;

        private EmployeeEmploymentDetailsUpdatedEvent event_to_handle;
        private UtcTime received_at;
        private EmployeeAuditTrail audit_trail;
    }
}
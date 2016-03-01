using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class AddPersonalDetailsAduitRecordWhenUpdated
                    : IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>
    {
        public void handle
                        (EmployeePersonalDetailsUpdatedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .update_employee_audit_trail()
                .add_employee_audit_record()
                .add_personal_details_updated_audit_record()
                .commit()
                ;
        }

        public AddPersonalDetailsAduitRecordWhenUpdated
                (GetOrCreateEmployeeAuditTrail<EmployeePersonalDetailsUpdatedEvent> get_or_create_employee_audit_trail_command
                , EmployeePersonalDetailsAuditRecordBuilder<EmployeePersonalDetailsUpdatedEvent> the_personal_details_audit_record_builder
                , EmployeeAuditRecordBuilder<EmployeePersonalDetailsUpdatedEvent> the_employee_audit_record_builder
                , Clock the_clock
                , IUnitOfWork the_unit_of_work)
        {
            get_or_create_employee_audit_trail = Guard.IsNotNull(get_or_create_employee_audit_trail_command, "get_or_create_employee_audit_trail_command");
            personal_details_audit_record_builder = Guard.IsNotNull(the_personal_details_audit_record_builder, "the_personal_details_audit_record_builder");
            employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder, "the_employee_audit_record_builder");
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private AddPersonalDetailsAduitRecordWhenUpdated set_event
                                                            (EmployeePersonalDetailsUpdatedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            received_at = clock.now();
            return this;
        }

        private AddPersonalDetailsAduitRecordWhenUpdated get_employee_audit_trail()
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

        private AddPersonalDetailsAduitRecordWhenUpdated update_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(audit_trail, "audit_trail");

            audit_trail.forename = event_to_handle.forename.normalise_for_persistence();
            audit_trail.surname = event_to_handle.surname.normalise_for_persistence();
            return this;
        }

        private AddPersonalDetailsAduitRecordWhenUpdated add_employee_audit_record()
        {
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employee_audit_record_builder.build(new NewEmployeeAuditRecordRequest(
                received_at: received_at
            ));

            audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddPersonalDetailsAduitRecordWhenUpdated add_personal_details_updated_audit_record()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = personal_details_audit_record_builder.build(new NewEmployeePersonalDetailsAuditModelRequest(
                forename: event_to_handle.forename,
                surname: event_to_handle.surname,
                othername: event_to_handle.othername,
                place_of_birth: event_to_handle.place_of_birth,
                date_of_birth: event_to_handle.date_of_birth,
                title_id: event_to_handle.title_id,
                title_description: event_to_handle.title_description,
                gender_id: event_to_handle.gender_id,
                gender_description: event_to_handle.gender_description,
                marital_status_id: event_to_handle.marital_status_id,
                marital_status_description: event_to_handle.marital_status_description,
                nationality_id: event_to_handle.nationality_id,
                nationality_description: event_to_handle.nationality_description,
                ethnic_origin_id: event_to_handle.ethnic_origin_id,
                ethnic_origin_description: event_to_handle.ethnic_origin_description,
                received_at: received_at
            ));

            audit_trail
                .personal_details_audit
                .Add(audit_record);

            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        private readonly GetOrCreateEmployeeAuditTrail<EmployeePersonalDetailsUpdatedEvent> get_or_create_employee_audit_trail;
        private readonly EmployeePersonalDetailsAuditRecordBuilder<EmployeePersonalDetailsUpdatedEvent> personal_details_audit_record_builder;
        private readonly EmployeeAuditRecordBuilder<EmployeePersonalDetailsUpdatedEvent> employee_audit_record_builder;
        private readonly Clock clock;
        private readonly IUnitOfWork unit_of_work;

        private EmployeePersonalDetailsUpdatedEvent event_to_handle;
        private UtcTime received_at;
        private EmployeeAuditTrail audit_trail;
    }
}
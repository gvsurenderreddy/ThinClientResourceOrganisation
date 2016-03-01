using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class AddContactDetailsAuditRecordWhenUpdated
                        : IEventSubscriber<EmployeeContactDetailsUpdatedEvent>
    {
        public void handle(EmployeeContactDetailsUpdatedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_contact_details_updated_audit_record()
                .commit()
                ;
        }

        private AddContactDetailsAuditRecordWhenUpdated set_event(EmployeeContactDetailsUpdatedEvent the_event_to_handle)
        {
            _event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            _received_at = _clock.now();

            return this;
        }

        private AddContactDetailsAuditRecordWhenUpdated get_employee_audit_trail()
        {
            Guard.IsNotNull(_event_to_handle, "event_to_handle");
            Guard.IsNotNull(_received_at, "received_at");
            Guard.IsNotNull(_get_or_create_employee_audit_trail, "_get_or_create_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest(
                employee_id: _event_to_handle.employee_id,
                received_at: _received_at
            );

            _audit_trail = _get_or_create_employee_audit_trail.execute(request);

            return this;
        }

        private AddContactDetailsAuditRecordWhenUpdated add_employee_audit_record()
        {
            Guard.IsNotNull(_employee_audit_record_builder, "_employee_audit_record_builder");
            Guard.IsNotNull(_audit_trail, "audit_trail");
            Guard.IsNotNull(_received_at, "received_at");

            var audit_record = _employee_audit_record_builder.build(new NewEmployeeAuditRecordRequest(
                received_at: _received_at
            ));

            _audit_trail.employee_audit.Add(audit_record);
            return this;
        }

        private AddContactDetailsAuditRecordWhenUpdated add_contact_details_updated_audit_record()
        {
            Guard.IsNotNull(_contact_details_audit_record_builder, "_contact_details_audit_record_builder");
            Guard.IsNotNull(_event_to_handle, "event_to_handle");
            Guard.IsNotNull(_audit_trail, "audit_trail");
            Guard.IsNotNull(_received_at, "received_at");

            var audit_record = _contact_details_audit_record_builder.build(new NewEmployeeContactDetailsAuditModelRequest(
                                                                                phone_number: _event_to_handle.phone_number,
                                                                                email: _event_to_handle.email,
                                                                                mobile: _event_to_handle.mobile,
                                                                                other: _event_to_handle.other,
                                                                                received_at: _received_at
                                                                            ));

            _audit_trail
                .contact_details_audit
                .Add(audit_record);

            return this;
        }

        private void commit()
        {
            _unit_of_work.Commit();
        }

        public AddContactDetailsAuditRecordWhenUpdated(GetOrCreateEmployeeAuditTrail<EmployeeContactDetailsUpdatedEvent> the_get_or_create_employee_audit_trail,
                                                        EmployeeContactDetailsAuditRecordBuilder<EmployeeContactDetailsUpdatedEvent> the_contact_details_audit_record_builder,
                                                        EmployeeAuditRecordBuilder<EmployeeContactDetailsUpdatedEvent> the_employee_audit_record_builder,
                                                        Clock the_clock,
                                                        IUnitOfWork the_unit_of_work
                                                      )
        {
            this._get_or_create_employee_audit_trail = Guard.IsNotNull(the_get_or_create_employee_audit_trail,
                                                                        "the_get_or_create_employee_audit_trail"
                                                                      );
            this._contact_details_audit_record_builder = Guard.IsNotNull(the_contact_details_audit_record_builder,
                                                                    "the_contact_details_audit_record_builder"
                                                                   );
            this._employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder,
                                                            "the_employee_audit_record_builder"
                                                            );
            this._unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            this._clock = Guard.IsNotNull(the_clock, "the_clock");
        }

        private readonly GetOrCreateEmployeeAuditTrail<EmployeeContactDetailsUpdatedEvent> _get_or_create_employee_audit_trail;
        private readonly EmployeeContactDetailsAuditRecordBuilder<EmployeeContactDetailsUpdatedEvent> _contact_details_audit_record_builder;
        private readonly EmployeeAuditRecordBuilder<EmployeeContactDetailsUpdatedEvent> _employee_audit_record_builder;
        private readonly Clock _clock;
        private readonly IUnitOfWork _unit_of_work;

        private EmployeeContactDetailsUpdatedEvent _event_to_handle;
        private UtcTime _received_at;
        private EmployeeAuditTrail _audit_trail;
    }
}
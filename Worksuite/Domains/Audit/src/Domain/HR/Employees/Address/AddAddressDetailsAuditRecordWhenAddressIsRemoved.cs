using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.Address
{
    public class AddAddressDetailsAuditRecordWhenAddressIsRemoved
                        : IEventSubscriber<EmployeeAddressRemovedEvent>
    {
        public void handle(EmployeeAddressRemovedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_address_details_removed_audit_record()
                .commit()
                ;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsRemoved set_event(EmployeeAddressRemovedEvent the_event_to_handle)
        {
            _event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            _received_at = _clock.now();

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsRemoved get_employee_audit_trail()
        {
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_received_at, "_received_at");
            Guard.IsNotNull(_get_or_create_employee_audit_trail, "_get_or_create_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest(employee_id: _event_to_handle.employee_id,
                                                                    received_at: _received_at
                                                                  );

            _audit_trail = _get_or_create_employee_audit_trail.execute(request);

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsRemoved add_employee_audit_record()
        {
            Guard.IsNotNull(_employee_audit_record_builder, "_employee_audit_record_builder");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_audit_record_builder
                                    .build(new NewEmployeeAuditRecordRequest(received_at: _received_at))
                                    ;

            _audit_trail
                    .employee_audit
                    .Add(audit_record)
                    ;

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsRemoved add_address_details_removed_audit_record()
        {
            Guard.IsNotNull(_employee_address_details_audit_record_builder, "_employee_address_details_audit_record_builder");
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_address_details_audit_record_builder
                                    .build(new NewEmployeeAddressDetailsAuditModelRequest(
                                                address_id: _event_to_handle.address_id,
                                                number_or_name: _event_to_handle.number_or_name,
                                                line_one: _event_to_handle.line_one,
                                                line_two: _event_to_handle.line_two,
                                                line_three: _event_to_handle.line_three,
                                                county: _event_to_handle.county,
                                                country: _event_to_handle.country,
                                                postcode: _event_to_handle.postcode,
                                                priority: _event_to_handle.priority,
                                                received_at: _received_at)
                                        )
                                    ;

            _audit_trail
                .address_details_audit
                .Add(audit_record)
                ;

            return this;
        }

        private void commit()
        {
            _unit_of_work.Commit();
        }

        public AddAddressDetailsAuditRecordWhenAddressIsRemoved(GetOrCreateEmployeeAuditTrail<EmployeeAddressRemovedEvent> the_get_or_create_employee_audit_trail,
                                                                EmployeeAuditRecordBuilder<EmployeeAddressRemovedEvent> the_employee_audit_record_builder,
                                                                EmployeeAddressDetailsAuditRecordBuilder<EmployeeAddressRemovedEvent> the_employee_address_details_audit_record_builder,
                                                                Clock the_clock,
                                                                IUnitOfWork the_unit_of_work
                                                               )
        {
            _get_or_create_employee_audit_trail = Guard.IsNotNull(the_get_or_create_employee_audit_trail,
                                                                    "the_get_or_create_employee_audit_trail"
                                                                 );
            _employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder,
                                                            "the_employee_audit_record_builder"
                                                            );
            _employee_address_details_audit_record_builder = Guard.IsNotNull(the_employee_address_details_audit_record_builder,
                                                                            "the_employee_address_details_audit_record_builder"
                                                                            );
            _clock = Guard.IsNotNull(the_clock, "the_clock");
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly GetOrCreateEmployeeAuditTrail<EmployeeAddressRemovedEvent> _get_or_create_employee_audit_trail;
        private readonly EmployeeAuditRecordBuilder<EmployeeAddressRemovedEvent> _employee_audit_record_builder;

        private readonly EmployeeAddressDetailsAuditRecordBuilder<EmployeeAddressRemovedEvent>
            _employee_address_details_audit_record_builder;

        private readonly Clock _clock;
        private readonly IUnitOfWork _unit_of_work;

        private EmployeeAddressRemovedEvent _event_to_handle;
        private UtcTime _received_at;
        private EmployeeAuditTrail _audit_trail;
    }
}
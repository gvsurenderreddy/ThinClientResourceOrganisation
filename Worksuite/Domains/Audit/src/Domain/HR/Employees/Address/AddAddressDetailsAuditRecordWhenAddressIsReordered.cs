using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.Address
{
    /// <summary>
    ///     This class is parent class that subscribes to 'EmployeeAddressReorderedEvent' events.
    /// </summary>
    /// <typeparam name="T">
    ///     T is a type of EmployeeAddressReorderedEvent
    /// </typeparam>
    public class AddAddressDetailsAuditRecordWhenAddressIsReordered<T>
                        : IEventSubscriber<T>
                where T : EmployeeAddressReorderedEvent
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

        private AddAddressDetailsAuditRecordWhenAddressIsReordered<T> set_event(T the_event_to_handle)
        {
            _event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            _received_at = _clock.now();

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsReordered<T> get_employee_audit_trail()
        {
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_received_at, "_received_at");
            Guard.IsNotNull(_get_or_create_employee_audit_trail, "_get_or_create_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest(
                                employee_id: _event_to_handle.employee_id,
                                received_at: _received_at
                );

            _audit_trail = _get_or_create_employee_audit_trail.execute(request);

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsReordered<T> add_employee_audit_record()
        {
            Guard.IsNotNull(_employee_audit_record_builder, "_employee_audit_record_builder");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_audit_record_builder
                                    .build(new NewEmployeeAuditRecordRequest(received_at: _received_at))
                                    ;

            _audit_trail.employee_audit.Add(audit_record);

            return this;
        }

        private AddAddressDetailsAuditRecordWhenAddressIsReordered<T> add_address_reordered_audit_record()
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
                                        received_at: _received_at))
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

        public AddAddressDetailsAuditRecordWhenAddressIsReordered(GetOrCreateEmployeeAuditTrail<T> the_get_or_create_employee_audit_trail,
                                                                    EmployeeAuditRecordBuilder<T> the_employee_audit_record_builder,
                                                                    EmployeeAddressDetailsAuditRecordBuilder<T> the_employee_address_details_audit_record_builder,
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

        private readonly GetOrCreateEmployeeAuditTrail<T>
            _get_or_create_employee_audit_trail;

        private readonly EmployeeAuditRecordBuilder<T> _employee_audit_record_builder;

        private readonly EmployeeAddressDetailsAuditRecordBuilder<T>
            _employee_address_details_audit_record_builder;

        private readonly Clock _clock;
        private readonly IUnitOfWork _unit_of_work;

        private T _event_to_handle;
        private UtcTime _received_at;
        private EmployeeAuditTrail _audit_trail;
    }

    /// <summary>
    ///     This class is a specific implementation for manual employee address re-order event, derived from the parent class 'AddAddressDetailsAuditRecordWhenAddressIsReordered'.
    /// </summary>
    public class AddAddressDetailsAuditRecordWhenAddressIsManuallyReordered
                    : AddAddressDetailsAuditRecordWhenAddressIsReordered<EmployeeAddressManualReorderedEvent>
    {
        public AddAddressDetailsAuditRecordWhenAddressIsManuallyReordered(GetOrCreateEmployeeAuditTrail<EmployeeAddressManualReorderedEvent> the_get_or_create_employee_audit_trail,
                                                                            EmployeeAuditRecordBuilder<EmployeeAddressManualReorderedEvent> the_employee_audit_record_builder,
                                                                            EmployeeAddressDetailsAuditRecordBuilder<EmployeeAddressManualReorderedEvent> the_employee_address_details_audit_record_builder,
                                                                            Clock the_clock,
                                                                            IUnitOfWork the_unit_of_work
                                                                         )
            : base(the_get_or_create_employee_audit_trail,
                    the_employee_audit_record_builder,
                    the_employee_address_details_audit_record_builder,
                    the_clock,
                    the_unit_of_work
                  ) { }
    }

    /// <summary>
    ///     This class is a specific implementation for auto employee address re-order event, derived from the parent class 'AddAddressDetailsAuditRecordWhenAddressIsReordered'.
    /// </summary>
    public class AddAddressDetailsAuditRecordWhenAddressIsAutomaticallyReordered
                    : AddAddressDetailsAuditRecordWhenAddressIsReordered<EmployeeAddressAutoReorderedEvent>
    {
        public AddAddressDetailsAuditRecordWhenAddressIsAutomaticallyReordered(GetOrCreateEmployeeAuditTrail<EmployeeAddressAutoReorderedEvent> the_get_or_create_employee_audit_trail,
                                                                                EmployeeAuditRecordBuilder<EmployeeAddressAutoReorderedEvent> the_employee_audit_record_builder,
                                                                                EmployeeAddressDetailsAuditRecordBuilder<EmployeeAddressAutoReorderedEvent> the_employee_address_details_audit_record_builder,
                                                                                Clock the_clock,
                                                                                IUnitOfWork the_unit_of_work
                                                                              )
            : base(the_get_or_create_employee_audit_trail,
                    the_employee_audit_record_builder,
                    the_employee_address_details_audit_record_builder,
                    the_clock,
                    the_unit_of_work
                  ) { }
    }
}
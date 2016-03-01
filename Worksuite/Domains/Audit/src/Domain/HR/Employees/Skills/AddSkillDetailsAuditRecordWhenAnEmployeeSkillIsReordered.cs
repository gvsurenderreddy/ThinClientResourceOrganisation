using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.Skills
{
    /// <summary>
    ///     This class is parent class that subscribes to 'EmployeeSkillReorderedEvent' events.
    /// </summary>
    /// <typeparam name="T">
    ///     T is a type of EmployeeSkillReorderedEvent
    /// </typeparam>
    public class AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<T>
                        : IEventSubscriber<T>
                where T : EmployeeSkillReorderedEvent
    {
        public void handle(T the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_skill_reordered_audit_record()
                .commit()
                ;
        }

        private AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<T> set_event(T the_event_to_handle)
        {
            _event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            _received_at = _clock.now();

            return this;
        }

        private AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<T> get_employee_audit_trail()
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

        private AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<T> add_employee_audit_record()
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

        private AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<T> add_skill_reordered_audit_record()
        {
            Guard.IsNotNull(_employee_skill_details_audit_record_builder, "_employee_address_details_audit_record_builder");
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_skill_details_audit_record_builder
                                    .build(new NewEmployeeSkillDetailsAuditModelRequest(
                                                    skill_id: _event_to_handle.employee_skill_id,
                                                    skill_description: _event_to_handle.skill_description,
                                                    priority: _event_to_handle.priority,
                                                    received_at: _received_at))
                                    ;

            _audit_trail
                .skill_details_audit
                .Add(audit_record)
                ;

            return this;
        }

        private void commit()
        {
            _unit_of_work.Commit();
        }

        public AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered(GetOrCreateEmployeeAuditTrail<T> the_get_or_create_employee_audit_trail,
                                                                    EmployeeAuditRecordBuilder<T> the_employee_audit_record_builder,
                                                                    EmployeeSkillDetailsAuditRecordBuilder<T> the_employee_skill_details_audit_record_builder,
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
            _employee_skill_details_audit_record_builder = Guard.IsNotNull(the_employee_skill_details_audit_record_builder,
                                                                           "the_employee_skill_details_audit_record_builder"
                                                                          );
            _clock = Guard.IsNotNull(the_clock, "the_clock");
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly GetOrCreateEmployeeAuditTrail<T> _get_or_create_employee_audit_trail;
        private readonly EmployeeAuditRecordBuilder<T> _employee_audit_record_builder;
        private readonly EmployeeSkillDetailsAuditRecordBuilder<T> _employee_skill_details_audit_record_builder;
        private readonly Clock _clock;
        private readonly IUnitOfWork _unit_of_work;

        private T _event_to_handle;
        private UtcTime _received_at;
        private EmployeeAuditTrail _audit_trail;
    }

    /// <summary>
    ///     This class is a specific implementation for manual employee address re-order event, derived from the parent class 'AddAddressDetailsAuditRecordWhenAddressIsReordered'.
    /// </summary>
    public class AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsManuallyReordered
                    : AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<EmployeeSkillManualReorderedEvent>
    {
        public AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsManuallyReordered(GetOrCreateEmployeeAuditTrail<EmployeeSkillManualReorderedEvent> the_get_or_create_employee_audit_trail,
                                                                            EmployeeAuditRecordBuilder<EmployeeSkillManualReorderedEvent> the_employee_audit_record_builder,
                                                                            EmployeeSkillDetailsAuditRecordBuilder<EmployeeSkillManualReorderedEvent> the_employee_skill_details_audit_record_builder,
                                                                            Clock the_clock,
                                                                            IUnitOfWork the_unit_of_work
                                                                         )
            : base(the_get_or_create_employee_audit_trail,
                    the_employee_audit_record_builder,
                    the_employee_skill_details_audit_record_builder,
                    the_clock,
                    the_unit_of_work
                  ) { }
    }

    /// <summary>
    ///     This class is a specific implementation for auto employee address re-order event, derived from the parent class 'AddAddressDetailsAuditRecordWhenAddressIsReordered'.
    /// </summary>
    public class AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsAutomaticallyReordered
                    : AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsReordered<EmployeeSkillAutoReorderedEvent>
    {
        public AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsAutomaticallyReordered(GetOrCreateEmployeeAuditTrail<EmployeeSkillAutoReorderedEvent> the_get_or_create_employee_audit_trail,
                                                                                EmployeeAuditRecordBuilder<EmployeeSkillAutoReorderedEvent> the_employee_audit_record_builder,
                                                                                EmployeeSkillDetailsAuditRecordBuilder<EmployeeSkillAutoReorderedEvent> the_employee_address_details_audit_record_builder,
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
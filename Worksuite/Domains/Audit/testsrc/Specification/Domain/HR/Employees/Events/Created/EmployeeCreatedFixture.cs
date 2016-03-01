using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created
{
    /// <summary>
    ///     Test fixture from EmployeeCreatedEvent.  Allows you to set up
    /// EmployeeCreatedEvent tests.
    /// </summary>
    public class EmployeeCreatedFixture
    {
        /// <summary>
        ///     Creaes a event with an id that will be unique if created from this fixture
        /// </summary>
        /// <returns>
        ///     A new EmployeeCreatedEvent
        /// </returns>
        public EmployeeCreatedEvent create_event()
        {
            return new EmployeeCreatedEvent
            {
                employee_id = ++new_event_id,
                employee_reference = "EB1",
                forename = "A forename",
                surname = "A surname",
            };
        }

        /// <summary>
        ///     all the employee audit trails
        /// </summary>
        public IEnumerable<EmployeeAuditTrail> all_employee_audit_trails { get { return employee_repository.Entities; } }

        /// <summary>
        ///     event handler that is being tests
        /// </summary>
        public CreateEmployeeAuditTrailWhenEmployeeCreated event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for
                                        (EmployeeIdentity created_event)
        {
            var audit_trail = all_employee_audit_trails
                                .SingleOrDefault(at => at.employee_id == created_event.employee_id)
                                ;

            return audit_trail != null
                    ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                    : new Nothing<EmployeeAuditTrail>()
                    ;
        }

        public Maybe<EmployeePersonalDetailsAuditRecord> get_last_personal_details_audit_record_for
                                                            (EmployeeIdentity employee_identity)
        {
            return get_employee_audit_trail_for(employee_identity)
                    .Match(

                        has_value:
                            audit_trail =>
                            {
                                var audit_record = audit_trail
                                                    .personal_details_audit
                                                    .LastOrDefault();

                                return audit_record != null
                                        ? new Just<EmployeePersonalDetailsAuditRecord>(audit_record) as Maybe<EmployeePersonalDetailsAuditRecord>
                                        : new Nothing<EmployeePersonalDetailsAuditRecord>()
                                        ;
                            },

                        nothing:
                            () => (new Nothing<EmployeePersonalDetailsAuditRecord>() as Maybe<EmployeePersonalDetailsAuditRecord>)
                    );
        }

        public Maybe<EmployeeContactDetailsAuditRecord> get_last_contact_details_audit_record_for(
                                                                EmployeeIdentity employee_identity)
        {
            return get_employee_audit_trail_for(employee_identity)
                        .Match(

                            has_value:
                                audit_trail =>
                                {
                                    var audit_record = audit_trail
                                                            .contact_details_audit
                                                            .LastOrDefault()
                                                            ;

                                    return audit_record != null
                                                ? new Just<EmployeeContactDetailsAuditRecord>(audit_record) as Maybe<EmployeeContactDetailsAuditRecord>
                                                : new Nothing<EmployeeContactDetailsAuditRecord>()
                                                ;
                                },

                            nothing:
                                () => (new Nothing<EmployeeContactDetailsAuditRecord>() as Maybe<EmployeeContactDetailsAuditRecord>)
                        );
        }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public EmployeeCreatedFixture()
        {
            employee_repository = DependencyResolver.resolve<IEntityRepository<EmployeeAuditTrail>>();
            event_handler = DependencyResolver.resolve<CreateEmployeeAuditTrailWhenEmployeeCreated>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            clock = DependencyResolver.resolve<FakeClock>();
        }

        private readonly IEntityRepository<EmployeeAuditTrail> employee_repository;
        private readonly FakeUnitOfWork unit_of_work;

        private int new_event_id = 0;
    }
}
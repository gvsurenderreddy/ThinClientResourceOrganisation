using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated
{
    public class EmployeePersonalDetailsUpdatedEventFixture
    {
        public EmployeePersonalDetailsUpdatedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            //
            // Note - We need to deal with the situation where an audit trail does not exist.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
                forename = "Fred",
                surname = "Smith",
            };
            employee_repository.add(audit_trail);

            return new EmployeePersonalDetailsUpdatedEvent
            {
                employee_id = audit_trail.employee_id,
                forename = audit_trail.forename,
                surname = audit_trail.surname,
                othername = "Sam",
                place_of_birth = "Leeds",
                date_of_birth = DateTime.Now.AddYears(-20),
                title_id = 1,
                title_description = "Mr",
                gender_id = 1,
                gender_description = "Male"
            };
        }

        public AddPersonalDetailsAduitRecordWhenUpdated event_handler { get; private set; }

        public Maybe<EmployeePersonalDetailsAuditRecord> get_last_personal_details_audit_record_for
                                                            (EmployeeIdentity for_employee)
        {
            return this
                    .get_employee_audit_trail_for(for_employee)
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

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for
                                        (EmployeeIdentity for_employee)
        {
            var audit_trail = employee_repository
                .Entities
                .SingleOrDefault(at => at.employee_id == for_employee.employee_id)
                ;

            return audit_trail != null
                ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                : new Nothing<EmployeeAuditTrail>()
                ;
        }

        public bool changes_were_committed()
        {
            return unit_of_work.commit_was_called;
        }

        public void clear_all_audit_trails()
        {
            employee_repository.clear();
        }

        public FakeClock clock { get; private set; }

        public EmployeePersonalDetailsUpdatedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddPersonalDetailsAduitRecordWhenUpdated>();

            employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            clock = DependencyResolver.resolve<FakeClock>();
        }

        private readonly FakeEmployeeRepository employee_repository;
        private readonly FakeUnitOfWork unit_of_work;
    }
}
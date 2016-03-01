using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees.Skills;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Reordered
{
    public class EmployeeSkillReorderedEventFixture
    {
        public EmployeeSkillAutoReorderedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
                forename = "Manoj",
                surname = "John"
            };

            _employee_repository.add(audit_trail);

            return new EmployeeSkillAutoReorderedEvent
            {
                employee_id = audit_trail.employee_id,
                employee_skill_id = (new Random()).Next(),
                skill_description = "some description",
                priority = 2
            };
        }

        public Maybe<EmployeeSkillDetailsAuditRecord> get_last_skill_details_audit_record_for(EmployeeSkillIdentity the_skill)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_skill.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                    .skill_details_audit
                                                    .SingleOrDefault(a => a.skill_id == the_skill.employee_skill_id)
                                                    ;

                            return audit_record != null
                                        ? new Just<EmployeeSkillDetailsAuditRecord>(audit_record) as Maybe<EmployeeSkillDetailsAuditRecord>
                                        : new Nothing<EmployeeSkillDetailsAuditRecord>()
                                        ;
                        },

                    nothing:
                        () => (new Nothing<EmployeeSkillDetailsAuditRecord>() as Maybe<EmployeeSkillDetailsAuditRecord>)

                );
        }

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for(EmployeeIdentity the_employee)
        {
            var audit_trail = _employee_repository
                                    .Entities
                                    .SingleOrDefault(e => e.employee_id == the_employee.employee_id)
                                    ;

            return audit_trail != null
                        ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                        : new Nothing<EmployeeAuditTrail>()
                        ;
        }

        public bool changes_were_committed()
        {
            return _unit_of_work.commit_was_called;
        }

        public void clear_all_audit_trails()
        {
            _employee_repository.clear();
        }

        public AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsAutomaticallyReordered event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeSkillReorderedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsAutomaticallyReordered>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}
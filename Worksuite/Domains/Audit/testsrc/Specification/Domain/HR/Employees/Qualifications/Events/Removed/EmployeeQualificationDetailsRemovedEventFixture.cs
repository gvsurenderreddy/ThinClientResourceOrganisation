using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees.Qualifications;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Removed
{
    public class EmployeeQualificationDetailsRemovedEventFixture
    {
        public EmployeeQualificationRemovedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
                forename = "John",
                surname = "Bank"
            };

            _employee_repository.add(audit_trail);

            return new EmployeeQualificationRemovedEvent
            {
                employee_id = audit_trail.employee_id,
                employee_qualification_id = (new Random()).Next(),
                employee_qualification_description = "Some description about the qualification"
            };
        }

        public Maybe<EmployeeQualificationDetailsAuditRecord> get_last_employee_qualification_details_audit_record_for(EmployeeQualificationIdentity the_qualification)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_qualification.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                .qualification_details_audit
                                                .SingleOrDefault(a => a.qualification_id == the_qualification.employee_qualification_id)
                                                ;

                            return audit_record != null
                                            ? new Just<EmployeeQualificationDetailsAuditRecord>(audit_record) as Maybe<EmployeeQualificationDetailsAuditRecord>
                                            : new Nothing<EmployeeQualificationDetailsAuditRecord>()
                                            ;
                        },

                        nothing:
                        () => (new Nothing<EmployeeQualificationDetailsAuditRecord>() as Maybe<EmployeeQualificationDetailsAuditRecord>)
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

        public AddQualificationDetailsAuditRecordWhenAnEmployeeQualificationIsRemoved event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeQualificationDetailsRemovedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddQualificationDetailsAuditRecordWhenAnEmployeeQualificationIsRemoved>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}
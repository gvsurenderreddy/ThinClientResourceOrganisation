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

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Created
{
    public class EmployeeQualificationDetailsCreatedEventFixture
    {
        public EmployeeQualificationCreatedEvent create_event()
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

            return new EmployeeQualificationCreatedEvent
            {
                employee_id = audit_trail.employee_id,
                employee_qualification_id = (new Random()).Next(),
                employee_qualification_description = "Some qualification description"
            };
        }

        public Maybe<EmployeeQualificationDetailsAuditRecord> get_last_qualification_details_audit_record_for(EmployeeQualificationIdentity the_employee_qualification)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_employee_qualification.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                    .qualification_details_audit
                                                    .Single()
                                                    ;

                            return audit_record != null
                                ? new Just<EmployeeQualificationDetailsAuditRecord>(audit_record) as Maybe<EmployeeQualificationDetailsAuditRecord>
                                : new Nothing<EmployeeQualificationDetailsAuditRecord>()
                                ;
                        },

                    nothing:
                        () =>
                            (new Nothing<EmployeeQualificationDetailsAuditRecord>() as Maybe<EmployeeQualificationDetailsAuditRecord>)

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

        public AddQualificationDetailsAuditRecordWhenEmployeeQualificationIsCreated event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeQualificationDetailsCreatedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddQualificationDetailsAuditRecordWhenEmployeeQualificationIsCreated>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}
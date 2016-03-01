using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Events.Updated
{
    public class EmployeeContactDetailsUpdatedEventFixture
    {
        public EmployeeContactDetailsUpdatedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            //
            // Note - We need to deal with the situation where an audit trail does not exist.
            var audit_trail = new EmployeeAuditTrail
                                    {
                                        employee_id = (new Random()).Next(),
                                        employee_reference = DateTime.Now.ToString(),
                                        forename = "Paul",
                                        surname = "Moore"
                                    };
            _employee_repository.add(audit_trail);

            return new EmployeeContactDetailsUpdatedEvent
                            {
                                employee_id = audit_trail.employee_id,
                                phone_number = "01758 951456",
                                email = "somebody@somedomain.com",
                                mobile = "07628874698",
                                other = "www.somedomain.com"
                            };
        }

        public Maybe<EmployeeContactDetailsAuditRecord> get_last_contact_details_audit_record_for(EmployeeIdentity the_employee)
        {
            return this
                .get_employee_audit_trail_for(the_employee)
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
                        () =>
                            (new Nothing<EmployeeContactDetailsAuditRecord>() as Maybe<EmployeeContactDetailsAuditRecord>)
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

        public AddContactDetailsAuditRecordWhenUpdated event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeContactDetailsUpdatedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddContactDetailsAuditRecordWhenUpdated>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}
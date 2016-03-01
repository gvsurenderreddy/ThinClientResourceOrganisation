using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated
{
    /// <summary>
    ///     TestFixture for EmployeeEmploymentDetailsUpdatedEvent. Allow you to set up
    /// and handlers for an EmployeeEmploymentDetailsUpdatedEvent.
    /// </summary>
    public class EmploymentDetailsUpdatedFixture
    {
        public void clear_all_audit_trails()
        {
            employee_repository.clear();
        }

        public bool changes_were_committed()
        {
            return unit_of_work.commit_was_called;
        }

        public Maybe<EmployeeEmploymentDetailsAuditRecord> get_last_employment_details_audit_record_for
                                                            (EmployeeIdentity created_event)
        {
            return get_employee_audit_trail_for(created_event)
                    .Match(

                        has_value:
                            audit_trail =>
                            {
                                var audit_record = audit_trail
                                                    .employment_details_audit
                                                    .LastOrDefault();

                                return audit_record != null
                                        ? new Just<EmployeeEmploymentDetailsAuditRecord>(audit_record) as Maybe<EmployeeEmploymentDetailsAuditRecord>
                                        : new Nothing<EmployeeEmploymentDetailsAuditRecord>()
                                        ;
                            },

                        nothing:
                            () => (new Nothing<EmployeeEmploymentDetailsAuditRecord>() as Maybe<EmployeeEmploymentDetailsAuditRecord>)
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

        public EmployeeEmploymentDetailsUpdatedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            //
            // Note - We need to deal with the situation where an audit trail does not exist.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
            };
            employee_repository.add(audit_trail);

            return new EmployeeEmploymentDetailsUpdatedEvent
            {
                employee_id = audit_trail.employee_id,
                employee_reference = DateTime.Now.AddDays(1).ToString(),
                job_title_id = (new Random()).Next(),
                job_title_description = "A job description",
                location_id = (new Random()).Next(),
                location_description = "A location description"
            };
        }

        public AddEmploymentDetailsAduitRecordWhenUpdated event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmploymentDetailsUpdatedFixture()
        {
            event_handler = DependencyResolver.resolve<AddEmploymentDetailsAduitRecordWhenUpdated>();
            employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            clock = DependencyResolver.resolve<FakeClock>();
        }

        private readonly FakeEmployeeRepository employee_repository;
        private readonly FakeUnitOfWork unit_of_work;
    }
}
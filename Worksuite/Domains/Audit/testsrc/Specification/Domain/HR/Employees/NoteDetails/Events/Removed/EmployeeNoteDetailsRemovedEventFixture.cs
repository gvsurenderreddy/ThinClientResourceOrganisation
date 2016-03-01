using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees.Notes;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Removed
{
    public class EmployeeNoteDetailsRemovedEventFixture
    {
        public EmployeeNoteRemovedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
                forename = "Paul",
                surname = "Whittam"
            };

            _employee_repository.add(audit_trail);

            return new EmployeeNoteRemovedEvent
            {
                employee_id = audit_trail.employee_id,
                note_id = (new Random()).Next(),
                notes = "Some notes"
            };
        }

        public Maybe<EmployeeNoteDetailsAuditRecord> get_last_employee_note_details_audit_record_for(NoteIdentity the_note)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_note.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                .note_details_audit
                                                .SingleOrDefault(a => a.note_id == the_note.note_id)
                                                ;

                            return audit_record != null
                                            ? new Just<EmployeeNoteDetailsAuditRecord>(audit_record) as Maybe<EmployeeNoteDetailsAuditRecord>
                                            : new Nothing<EmployeeNoteDetailsAuditRecord>()
                                            ;
                        },

                        nothing:
                        () => (new Nothing<EmployeeNoteDetailsAuditRecord>() as Maybe<EmployeeNoteDetailsAuditRecord>)
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

        public AddNoteDetailsAuditRecordWhenNoteIsRemoved event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeNoteDetailsRemovedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddNoteDetailsAuditRecordWhenNoteIsRemoved>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}
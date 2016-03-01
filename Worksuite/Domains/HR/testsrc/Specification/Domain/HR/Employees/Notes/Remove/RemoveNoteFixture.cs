using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.HR.Employees.Notes.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Remove
{
    public class RemoveNoteFixture
    {
        public NoteIdentity remove_request
        {
            get
            {
                return _note_identity_helper.get_identity();
            }
        }

        public Maybe<RemoveResponse> response
        {
            get;
            private set;
        }

        public void execute_command()
        {
            response = _command.execute(remove_request).to_maybe();
        }

        public Maybe<EmployeeNoteRemovedEvent> get_last_note_removed_event_for(NoteIdentity the_note)
        {
            var removed_event = _event_publisher
                                    .published_events
                                    .FirstOrDefault(a => a.note_id == the_note.note_id)
                                    ;

            return removed_event != null
                        ? new Just<EmployeeNoteRemovedEvent>(removed_event) as Maybe<EmployeeNoteRemovedEvent>
                        : new Nothing<EmployeeNoteRemovedEvent>()
                        ;
        }

        public RemoveNoteFixture()
        {
            this.response = new Nothing<RemoveResponse>();
            _note_identity_helper = DependencyResolver.resolve<NoteIdentityHelper>();

            _command = DependencyResolver.resolve<IRemove>();
            _event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeNoteRemovedEvent>>();
        }

        private readonly NoteIdentityHelper _note_identity_helper;
        private readonly IRemove _command;
        private readonly FakeEventPublisher<EmployeeNoteRemovedEvent> _event_publisher;
    }
}
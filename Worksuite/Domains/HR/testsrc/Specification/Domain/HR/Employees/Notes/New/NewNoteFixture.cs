using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.New
{
    public class NewNoteFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<NewNoteRequest, NewNoteResponse, INewNote, Note>
    {
        public Maybe<EmployeeNoteCreatedEvent> get_last_note_created_event_for(Note the_note)
        {
            var created_event = event_publisher
                                    .published_events
                                    .LastOrDefault(e => e.note_id == the_note.id)
                                    ;

            return created_event != null
                            ? new Just<EmployeeNoteCreatedEvent>(created_event) as Maybe<EmployeeNoteCreatedEvent>
                            : new Nothing<EmployeeNoteCreatedEvent>()
                            ;
        }

        public override Note entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return repository
                        .Entities
                        .Single(e => e.id == response.result.employee_id)
                        .Note
                        .Single(n => n.id == response.result.note_id)
                        ;
            }
        }

        public NewNoteFixture
                       (INewNote the_command
                       , IRequestHelper<NewNoteRequest> the_request_builder
                       , IEntityRepository<Employee> the_employee_repository
                       , FakeEventPublisher<EmployeeNoteCreatedEvent> the_event_publisher)
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeNoteCreatedEvent> event_publisher;
    }
}
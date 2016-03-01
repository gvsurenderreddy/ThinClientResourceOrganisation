using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Update
{
    public class UpdateNoteFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateRequest, UpdateResponse, IUpdate, Note>
    {
        public Maybe<EmployeeNoteUpdatedEvent> get_last_note_updated_event_for(Note the_note)
        {
            var created_event = event_publisher
                                    .published_events
                                    .LastOrDefault(a => a.note_id == the_note.id)
                                    ;

            return created_event != null
                        ? new Just<EmployeeNoteUpdatedEvent>(created_event) as Maybe<EmployeeNoteUpdatedEvent>
                        : new Nothing<EmployeeNoteUpdatedEvent>()
                        ;
        }

        public override Note entity
        {
            get
            {
                return repository
                        .Entities
                        .Single(e => e.id == response.result.employee_id)
                        .Note
                        .Single(n => n.id == response.result.note_id)
                        ;
            }
        }

        public UpdateNoteFixture
                       (IUpdate the_command,
                        IRequestHelper<UpdateRequest> the_request_builder,
                        IEntityRepository<Employee> the_employee_repository,
                        FakeEventPublisher<EmployeeNoteUpdatedEvent> the_event_publisher
                       )
            : base(the_command,
                   the_request_builder
                  )
        {
            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher = Guard.IsNotNull(the_event_publisher, "the_event_publisher");
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly FakeEventPublisher<EmployeeNoteUpdatedEvent> event_publisher;
    }
}
using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New
{
    public class NewNote : INewNote
    {
        public NewNoteResponse execute(NewNoteRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .authorize()
                    .sanatise_request()
                    .validate_request()
                    .find_employee()
                    .create_note()
                    .commit()
                    .publish_note_created_event()
                    .build_response();
        }

        private NewNote set_request(NewNoteRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<NoteIdentity, NewNoteResponse>();
            response_builder.set_response(new NoteIdentity { employee_id = request.employee_id, note_id = Null.Id });

            return this;
        }

        public NewNote authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            return this;
        }

        private NewNote sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request = new NewNoteRequest
            {
                employee_id = request.employee_id,
                note = request.note.normalise_for_persistence()
            };
            return this;
        }

        private NewNote validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(validator, "validator");

            validator.field("note").is_madatory(request.note, ValidationMessages.error_00_0017);
            response_builder.add_errors(validator.errors);

            return this;
        }

        public NewNote find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(repository, "repository");

            employee = repository
                        .Entities
                        .Single(e => e.id == request.employee_id);

            return this;
        }

        private NewNote create_note()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Note, "employee.Note");

            new_note = new Note
            {
                Notes = request.note,
            };
            employee.Note.Add(new_note);

            return this;
        }

        private NewNote commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private NewNote publish_note_created_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(new_note, "new_note");

            event_publisher_note_created.publish(new EmployeeNoteCreatedEvent
            {
                employee_id = employee.id,
                note_id = new_note.id,
                notes = new_note.Notes
            });

            return this;
        }

        private NewNoteResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            else
            {
                response_builder.add_message(ValidationMessages.confirmation_04_0001);

                response_builder.set_response(new NoteIdentity { employee_id = employee.id, note_id = new_note.id });
            }

            return response_builder.build();
        }

        public NewNote(IEntityRepository<Employee> the_repository
                , IUnitOfWork the_unit_of_work
                , ICanAddNewNote the_execute_permission
                , Validator the_validator
                , IEventPublisher<EmployeeNoteCreatedEvent> the_event_publisher_note_created
                )
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            validator = the_validator;
            event_publisher_note_created = Guard.IsNotNull(the_event_publisher_note_created, "the_event_publisher_note_created");
        }

        private readonly ICanAddNewNote execute_permission;
        private readonly IEntityRepository<Employee> repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly Validator validator;
        private readonly IEventPublisher<EmployeeNoteCreatedEvent> event_publisher_note_created;

        private Employee employee;
        private Note new_note;
        private NewNoteRequest request;
        private ResponseBuilder<NoteIdentity, NewNoteResponse> response_builder;
    }
}
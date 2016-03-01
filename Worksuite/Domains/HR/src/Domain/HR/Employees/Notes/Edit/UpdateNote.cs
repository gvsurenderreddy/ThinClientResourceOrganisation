using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Edit
{
    public class UpdateNote : IUpdate
    {
        public UpdateResponse execute(UpdateRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .authorize()
                    .find_employee()
                    .find_note()
                    .sanatise_request()
                    .validate_request()
                    .update_note()
                    .commit()
                    .publish_note_updated_event()
                    .build_response()
                    ;
        }

        private UpdateNote set_request
                                (UpdateRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<NoteIdentity, UpdateResponse>();

            response_builder
                .set_response(new NoteIdentity { employee_id = request.employee_id, note_id = request.note_id })
                ;

            return this;
        }

        private UpdateNote authorize()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            if (!execute_permission.IsGrantedFor(request))
            {
                response_builder.add_error(ValidationMessages.default_update_permission_not_granted);
            }
            return this;
        }

        public UpdateNote find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = repository
                        .Entities
                        .Single(e => e.id == request.employee_id);

            return this;
        }

        public UpdateNote find_note()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Note, "employee.Note");

            note = employee
                        .Note
                        .SingleOrDefault(a => a.id == request.note_id);

            if (note == null)
            {
                response_builder.add_error("TODO: note-not-found  Error message is yet to be defined");
            }

            return this;
        }

        private UpdateNote sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request = new UpdateRequest
            {
                employee_id = request.employee_id,
                note_id = note.id,
                note = request.note.normalise_for_persistence()
            };

            return this;
        }

        private UpdateNote validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(validator, "validator");

            validator.field("note").is_madatory(request.note, ValidationMessages.error_00_0017);
            response_builder.add_errors(validator.errors);

            return this;
        }

        private UpdateNote update_note()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(note, "note");

            note.Notes = request.note;

            return this;
        }

        private UpdateNote commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private UpdateNote publish_note_updated_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(note, "note");

            event_publisher_note_updated.publish(new EmployeeNoteUpdatedEvent
            {
                employee_id = employee.id,
                note_id = note.id,
                notes = note.Notes
            });

            return this;
        }

        private UpdateResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }
            else
            {
                response_builder.add_message(ValidationMessages.update_was_successfull);

                response_builder
                                .set_response(new NoteIdentity { employee_id = employee.id, note_id = note.id })
                                ;
            }

            return response_builder.build();
        }

        public UpdateNote(IUnitOfWork the_unit_of_work
                        , IEntityRepository<Employee> the_repository
                        , Validator the_validator
                        , ICanUpdateNote the_execute_permission
                        , IEventPublisher<EmployeeNoteUpdatedEvent> the_event_publisher_note_updated)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            execute_permission = Guard.IsNotNull(the_execute_permission, "the_execute_permission");
            event_publisher_note_updated = Guard.IsNotNull(the_event_publisher_note_updated, "the_event_publisher_note_updated");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> repository;
        private readonly Validator validator;
        private readonly ICanUpdateNote execute_permission;
        private readonly IEventPublisher<EmployeeNoteUpdatedEvent> event_publisher_note_updated;

        private UpdateRequest request;
        private Employee employee;
        private Note note;
        private ResponseBuilder<NoteIdentity, UpdateResponse> response_builder;
    }
}
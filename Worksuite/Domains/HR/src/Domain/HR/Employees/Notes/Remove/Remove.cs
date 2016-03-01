using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Remove
{
    public class Remove : IRemove
    {
        public RemoveResponse execute(NoteIdentity the_request)
        {
            return this
                    .set_request(the_request)
                    .find_employee()
                    .find_note()
                    .create_employee_note_removed_event()
                    .remove_note()
                    .commit()
                    .publish_note_removed_event()
                    .build_response()
                    ;
        }

        private Remove set_request(NoteIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<NoteIdentity, RemoveResponse>();

            response_builder
                .set_response(new NoteIdentity { employee_id = Null.Id, note_id = Null.Id })
                ;

            return this;
        }

        private Remove find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = employee_repository
                        .Entities
                        .Single(e => e.id == request.employee_id)
                        ;

            return this;
        }

        private Remove find_note()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Note, "employee.Note");

            note = employee
                        .Note
                        .Single(a => a.id == request.note_id)
                        ;

            return this;
        }

        private Remove create_employee_note_removed_event()
        {
            if (response_builder.has_errors) return this;
            if (note == null) return this;  // To do: sort out internal error handling and 404 (e.g the note no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(note, "note");

            employee_note_removed_event = new EmployeeNoteRemovedEvent
            {
                employee_id = employee.id,
                note_id = note.id,
                notes = note.Notes
            };

            return this;
        }

        private Remove remove_note()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;  // To do: sort out internal error handling and 404 (e.g the employee no longer exists)
            if (note == null) return this;  // To do: sort out internal error handling and 404 (e.g the note no longer exists do we need to tell the user that it had already been removed )

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.Note, "employee.Note");

            employee.Note.Remove(note);

            employee_repository.remove(note);

            return this;
        }

        private Remove commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            return this;
        }

        private Remove publish_note_removed_event()
        {
            if (response_builder.has_errors) return this;

            event_publisher_note_removed.publish(employee_note_removed_event);

            return this;
        }

        private RemoveResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.remove_was_successfull);
            }
            return response_builder.build();
        }

        public Remove(IUnitOfWork the_unit_of_work,
                      IEntityRepository<Employee> the_employee_repository,
                      IEventPublisher<EmployeeNoteRemovedEvent> the_event_publisher_note_removed
                     )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_title_repository");
            event_publisher_note_removed = Guard.IsNotNull(the_event_publisher_note_removed, "the_event_publisher_note_removed");
        }

        private readonly IEntityRepository<Employee> employee_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<EmployeeNoteRemovedEvent> event_publisher_note_removed;

        private NoteIdentity request;
        private Employee employee;
        private Note note;
        private ResponseBuilder<NoteIdentity, RemoveResponse> response_builder;
        private EmployeeNoteRemovedEvent employee_note_removed_event;
    }
}
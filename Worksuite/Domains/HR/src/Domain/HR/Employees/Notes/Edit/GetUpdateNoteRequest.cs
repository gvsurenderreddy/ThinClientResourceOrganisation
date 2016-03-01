using System.Linq;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Edit
{
    public class GetUpdateNoteRequest : IGetUpdateRequest
    {
        public GetUpdateNoteRequest(IEntityRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        public Response<UpdateRequest> execute(NoteIdentity request)
        {
            var employee = repository
                             .Entities
                             .Single(e => e.id == request.employee_id)
                             ;

            var note = employee.Note.Single(a => a.id == request.note_id);

            return new Response<UpdateRequest>
            {
                result = new UpdateRequest
                {
                    note = note.Notes,
                    employee_id = request.employee_id,
                    note_id = request.note_id,
                }
            };
        }

        private IEntityRepository<Employee> repository;
    }
}
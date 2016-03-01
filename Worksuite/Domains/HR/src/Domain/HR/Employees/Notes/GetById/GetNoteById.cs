using System.Linq;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.GetById
{
    public class GetNoteById : IGetNoteById
    {
        public GetNoteById(IQueryRepository<Employee> the_employee_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
        }

        public Response<EmployeeNoteDetails> execute(NoteIdentity request)
        {
            var employee = employee_repository.Entities.Single(e => e.id == request.employee_id);

            var note = employee.Note.Single(a => a.id == request.note_id);

            return new Response<EmployeeNoteDetails>
            {
                result = new EmployeeNoteDetails
                {
                    note = note.Notes,
                    note_id = request.note_id,
                    employee_id = request.employee_id,
                }
            };
        }

        private readonly IQueryRepository<Employee> employee_repository;
    }
}
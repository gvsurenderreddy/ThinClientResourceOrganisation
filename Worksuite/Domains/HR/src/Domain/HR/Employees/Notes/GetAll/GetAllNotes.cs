using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.GetAll
{
    public class GetAllNotes : IGetAllNotes
    {
        public GetAllNotes(IQueryRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private IQueryRepository<Employee> repository;
        private Employee employee;


        public Response<IEnumerable<EmployeeNoteDetails>> execute(EmployeeIdentity request)
        {
            employee = repository
                      .Entities
                      .Single(e => e.id == request.employee_id);

            return new Response<IEnumerable<EmployeeNoteDetails>>
            {
                result = employee.Note.Select(n => new EmployeeNoteDetails
                {
                    employee_id = request.employee_id,
                    note = n.Notes,
                    note_id = n.id,
                }),
            };
        }
    }
}
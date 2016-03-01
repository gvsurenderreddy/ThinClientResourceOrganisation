using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New
{
    public class GetNewNoteRequest : IGetNewNoteRequest
    {
        public NewNoteRequest execute(EmployeeIdentity request)
        {
            return new NewNoteRequest
            {
                note=string.Empty,
                employee_id = request.employee_id,
            };
        }
    }
}
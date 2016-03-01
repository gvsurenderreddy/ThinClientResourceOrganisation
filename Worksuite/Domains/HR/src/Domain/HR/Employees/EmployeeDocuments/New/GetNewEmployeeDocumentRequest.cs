using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public class GetNewEmployeeDocumentRequest : IGetNewEmployeeDocumentRequest
    {
        public NewEmployeeDocumentRequest execute(EmployeeIdentity request)
        {
            return new NewEmployeeDocumentRequest
            {
                name = string.Empty,
                employee_id = request.employee_id,
                content_type = string.Empty,
            };
        }
    }
}
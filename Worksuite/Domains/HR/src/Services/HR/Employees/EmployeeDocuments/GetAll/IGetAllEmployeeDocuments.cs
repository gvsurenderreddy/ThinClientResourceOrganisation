using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll
{
    public interface IGetAllEmployeeDocuments : IQuery<EmployeeIdentity, GetAllEmployeeDocumentsResponse> { }
}
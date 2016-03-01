using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public interface IGetNewEmployeeDocumentRequest : ICommand<EmployeeIdentity, NewEmployeeDocumentRequest> { }
}
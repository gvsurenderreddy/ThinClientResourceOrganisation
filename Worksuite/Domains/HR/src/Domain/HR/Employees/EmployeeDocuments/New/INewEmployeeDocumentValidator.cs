using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public interface INewEmployeeDocumentValidator
    {
        IEnumerable<ResponseMessage> validate(NewEmployeeDocumentRequest request);
    }
}
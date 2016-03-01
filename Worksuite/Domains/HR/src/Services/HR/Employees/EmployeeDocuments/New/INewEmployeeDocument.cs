using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New {

    public interface INewEmployeeDocument 
                        : IResponseCommand<NewEmployeeDocumentRequest, NewEmployeeDocumentResponse>{}
}
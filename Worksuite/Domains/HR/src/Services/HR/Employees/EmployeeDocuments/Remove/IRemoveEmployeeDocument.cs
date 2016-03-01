using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Remove {

    public interface IRemoveEmployeeDocument 
                        : IResponseCommand<EmployeeDocumentIdentity, RemoveEmployeeDocumentResponse> { }
}
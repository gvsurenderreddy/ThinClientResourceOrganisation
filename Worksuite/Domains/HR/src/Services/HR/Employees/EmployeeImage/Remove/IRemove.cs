using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Remove {

    public interface IRemove 
                        : IResponseCommand<EmployeeIdentity, RemoveResponse> { }
}

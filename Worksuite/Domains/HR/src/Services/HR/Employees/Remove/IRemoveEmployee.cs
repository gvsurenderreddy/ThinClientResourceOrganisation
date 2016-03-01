using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Remove {

    /// <summary>
    ///     Removes an employee record from the system.  NOTE - if this is 
    /// successfull the employee details are permanently removed and not recoverable.
    /// </summary>
    public interface IRemoveEmployee 
                        : IResponseCommand<EmployeeIdentity, RemoveResponse> {}
}

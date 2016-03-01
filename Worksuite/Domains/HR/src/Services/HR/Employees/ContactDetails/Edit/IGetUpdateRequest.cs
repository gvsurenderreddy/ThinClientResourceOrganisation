using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit
{
    /// <summary>
    ///     Gets an update request for an employees personal details.
    /// </summary>
    public interface IGetUpdateRequest : ICommand<EmployeeIdentity, Response<UpdateRequest>> { }
}

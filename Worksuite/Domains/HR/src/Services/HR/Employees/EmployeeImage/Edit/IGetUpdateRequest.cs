using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit
{
    public interface IGetUpdateRequest : ICommand<EmployeeIdentity, Response<UpdateRequest>> { }
}

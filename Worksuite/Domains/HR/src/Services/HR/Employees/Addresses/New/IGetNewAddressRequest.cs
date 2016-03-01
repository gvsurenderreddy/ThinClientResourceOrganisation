using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.New
{
    public interface IGetNewAddressRequest : ICommand<EmployeeIdentity,NewAddressRequest> { }
}
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New
{
    public interface IGetNewEmployeeImageRequest : ICommand<EmployeeIdentity, NewEmployeeImageRequest> { }
}

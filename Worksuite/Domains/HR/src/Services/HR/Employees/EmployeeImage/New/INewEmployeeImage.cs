using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New
{
    public interface INewEmployeeImage : IResponseCommand<NewEmployeeImageRequest, NewEmployeeImageResponse, EmployeeImageIdentity> {}
}

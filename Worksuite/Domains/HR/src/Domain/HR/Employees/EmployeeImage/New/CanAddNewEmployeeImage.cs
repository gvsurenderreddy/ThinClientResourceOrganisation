using WTS.WorkSuite.Domain.Framework.Permissions;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;

namespace WTS.WorkSuite.Domain.HR.Employees.EmployeeImage.New
{
    public class CanAddNewEmployeeImage : PermissionGranted<NewEmployeeImageRequest>, ICanAddNewEmployeeImage { }
}

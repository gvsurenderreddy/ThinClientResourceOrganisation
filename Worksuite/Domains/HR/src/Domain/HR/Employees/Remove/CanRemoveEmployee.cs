using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public class CanRemoveEmployee : PermissionGranted<RemoveEmployeeRequest>, ICanRemoveEmployee { }
}

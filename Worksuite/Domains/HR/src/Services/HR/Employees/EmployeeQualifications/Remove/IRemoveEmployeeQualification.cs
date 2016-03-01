using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Remove
{
    public interface IRemoveEmployeeQualification
                            : IResponseCommand< EmployeeQualificationIdentity, RemoveEmployeeQualificationResponse > {}
}
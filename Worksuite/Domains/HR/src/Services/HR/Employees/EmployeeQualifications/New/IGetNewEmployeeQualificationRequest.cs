using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public interface IGetNewEmployeeQualificationRequest
                            : ICommand< EmployeeIdentity, NewEmployeeQualificationRequest > {}
}
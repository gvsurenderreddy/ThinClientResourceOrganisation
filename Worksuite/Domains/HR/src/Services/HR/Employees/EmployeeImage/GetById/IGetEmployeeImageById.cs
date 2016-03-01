using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Details;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById
{
    public interface IGetImageOfAnEmployee : IQuery<EmployeeIdentity, Response<EmployeeImageDetails>> { }
}

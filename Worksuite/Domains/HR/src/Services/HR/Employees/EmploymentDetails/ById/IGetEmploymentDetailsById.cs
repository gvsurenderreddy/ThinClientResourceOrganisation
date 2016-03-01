using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.ById
{
    public interface IGetEmploymentDetailsById : IQuery<EmployeeIdentity, Response<EmployeeEmploymentDetails>> {}
}

using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSummary
{
    public interface IGetEmployeeSummary : IQuery<EmployeeIdentity, Response<EmployeeSummaryDetails>>{}
}
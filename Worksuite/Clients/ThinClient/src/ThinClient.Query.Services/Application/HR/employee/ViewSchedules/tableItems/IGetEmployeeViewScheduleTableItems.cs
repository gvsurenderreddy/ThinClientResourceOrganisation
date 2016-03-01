using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems
{
    public interface IGetEmployeeViewScheduleTableItems : IQuery<EmployeeIdentity, GetEmployeeViewScheduleTableItemsResponse>
    {
    }
}

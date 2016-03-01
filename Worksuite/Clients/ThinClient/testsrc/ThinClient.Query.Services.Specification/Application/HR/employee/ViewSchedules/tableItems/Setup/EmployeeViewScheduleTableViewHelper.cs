using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup
{
    public class EmployeeViewScheduleTableViewHelper 
                    : EnityHelper<EmployeeViewScheduleTableView, 
                    int, EmployeeViewScheduleTableViewBuilder,
                    FakeEmployeeViewScheduleTableViewRepository>
    {
    }
}

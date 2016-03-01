using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup
{
    public class FakeEmployeeViewScheduleTableViewRepository : FakeEntityRepository<EmployeeViewScheduleTableView,int>
    {
        public FakeEmployeeViewScheduleTableViewRepository()
            : base(new IntIdentityProvider<EmployeeViewScheduleTableView>())
        {
        }
    }
}

using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems
{
    public class GetEmployeeViewScheduleTableItemsSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<GetEmployeeViewScheduleTableItemsFixture>();
        }

        protected GetEmployeeViewScheduleTableItemsFixture fixture;
    }

}

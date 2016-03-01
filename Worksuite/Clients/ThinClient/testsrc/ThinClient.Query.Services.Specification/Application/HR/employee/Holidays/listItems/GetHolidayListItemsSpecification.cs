using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems
{
    public class GetHolidayListItemsSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetHolidayListItemsFixture>();
        }

        protected GetHolidayListItemsFixture fixture;
    }
}

using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems
{
    public class GetSicknessListItemsSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetSicknessListItemsFixture>();
        }

        protected GetSicknessListItemsFixture fixture;
    }
}

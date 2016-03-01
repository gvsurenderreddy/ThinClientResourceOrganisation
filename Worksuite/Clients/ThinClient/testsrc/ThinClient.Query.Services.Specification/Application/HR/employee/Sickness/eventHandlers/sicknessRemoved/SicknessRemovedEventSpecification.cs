using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.eventHandlers.sicknessRemoved
{
    public class SicknessRemovedEventSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<SicknessRemovedEventFixture>();
        }

        protected SicknessRemovedEventFixture fixture;
    }
}

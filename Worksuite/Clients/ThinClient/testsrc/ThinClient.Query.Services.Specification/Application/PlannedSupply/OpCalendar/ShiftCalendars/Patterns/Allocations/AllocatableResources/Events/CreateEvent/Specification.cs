using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.OpCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.FindEmployeeView.CreateEvent
{
    public class EmployeeCreateEventSpecification :ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<EmployeeCreateEventFixture>();
        }

        protected EmployeeCreateEventFixture fixture;
    }
}

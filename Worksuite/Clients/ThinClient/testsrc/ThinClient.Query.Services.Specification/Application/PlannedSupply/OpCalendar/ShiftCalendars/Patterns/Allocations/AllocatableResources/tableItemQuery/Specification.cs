using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItemQuery
{
    public class GetAllocatableResourcesTableItemSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<GetAllocatableResourcesTableItemFixture>();
        }

        protected GetAllocatableResourcesTableItemFixture fixture;
    }
}

using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByCalendar
{
    public class GetResourceAllocationsSpecification : PlannedSupplySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<GetResourceAllocationsFixture>();
        }

        protected GetResourceAllocationsFixture fixture;
    }
}

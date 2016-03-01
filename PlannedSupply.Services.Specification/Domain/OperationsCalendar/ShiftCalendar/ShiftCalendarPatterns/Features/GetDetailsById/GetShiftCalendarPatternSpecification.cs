using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.GetDetailsById
{
    public class GetShiftCalendarPatternSpecification : PlannedSupplySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetShiftCalendarPatternFixture>();
        }

        protected GetShiftCalendarPatternFixture fixture;
         
    }
}
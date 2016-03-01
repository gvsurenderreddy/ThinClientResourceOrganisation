using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetAllDetails
{
    public class GetAllOccurrencesDetailsSpecification : PlannedSupplySpecification
    {

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetAllOccurrencesDetailsFixture>();
        }

        protected GetAllOccurrencesDetailsFixture fixture;
    }
}

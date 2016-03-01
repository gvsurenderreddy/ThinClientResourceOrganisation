using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetSingleDetails
{
    public class GetSingleOccurrenceDetailsSpecification : PlannedSupplySpecification
    {

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetSingleOccurrenceDetailsFixture>();
        }

        protected GetSingleOccurrenceDetailsFixture fixture;
    }
}

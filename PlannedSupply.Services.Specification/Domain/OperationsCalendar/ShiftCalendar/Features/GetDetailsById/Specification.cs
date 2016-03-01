using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.GetDetailsById
{
    public class GetShiftCalendarDetailsByIdSpecification : PlannedSupplySpecification
    {

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<GetShiftCalendarDetailsByIdFixture>();
        }

        protected GetShiftCalendarDetailsByIdFixture fixture;
    }
}

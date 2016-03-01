using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Remove
{
    [TestClass]
    public class Remove_shift_calendar_pattern
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void a_shift_calendar_removed_event()
        {
            fixture.execute_command(null);

            fixture
                .get_shift_calendar_pattern_removed_event_for(fixture.request)
                .Match(

                    has_value:
                        removed_event => { },

                    nothing:
                        () => Assert.Fail("An ShiftCalendarPatternRemoveEvent was not published")
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<RemoveShiftCalendarPatternFixture>();
        }

        private RemoveShiftCalendarPatternFixture fixture;
    }
}
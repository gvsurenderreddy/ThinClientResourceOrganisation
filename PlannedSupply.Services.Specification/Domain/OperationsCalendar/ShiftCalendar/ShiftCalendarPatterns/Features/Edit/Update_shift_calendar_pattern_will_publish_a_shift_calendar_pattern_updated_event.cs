using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit
{
    [TestClass]
    public class Update_shift_calendar_pattern
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void will_publish_a_shift_calendar_pattern_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_shift_calendar_pattern_update_event_for( fixture.request )
                .Match(

                    has_value:
                        update_event => { },

                    nothing:
                        () => Assert.Fail("An ShiftCalendarPatternUpdateEvent was not published")
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<UpdateShiftCalendarPatternFixture>();
        }

        private UpdateShiftCalendarPatternFixture fixture;
    }
}
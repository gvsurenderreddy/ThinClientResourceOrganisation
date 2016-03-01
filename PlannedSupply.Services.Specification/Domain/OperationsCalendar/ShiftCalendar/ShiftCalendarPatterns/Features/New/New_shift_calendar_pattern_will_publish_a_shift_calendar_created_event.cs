using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New
{
    [TestClass]
    public class New_shift_calendar_pattern_will_publish_a_shift_calendar_created_event
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void will_publish_a_shift_calendar_pattern_created_event()
        {
            fixture.execute_command(null);

            fixture
                .get_shift_calendar_pattern_created_event_for(fixture.create_new_request)
                .Match(

                    has_value:
                        update_event => { },

                    nothing:
                        () => Assert.Fail("An ShiftCalendarPatternCreatedEvent was not published")
                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<NewShiftCalendarPatternFixture>();
        }

        private NewShiftCalendarPatternFixture fixture;
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New
{
    public class New_shift_calendar_pattern_will_publish_auto_reordered_events
    {
        [TestClass]
        public class WhenAShiftCalendarPatternIsCreated
                        : ReorderShiftCalendarPatternSpecifiction
        {
            [TestMethod]
            public void that_should_raise_shift_calendar_pattern_auto_reordered_events()
            {
                // Act
                var shift_calendar_identity = new ShiftCalendarIdentity
                {
                    operations_calendar_id = operational_calendar.id,
                    shift_calendar_id = shift_calendar.id
                };

                fixture.execute_command(shift_calendar_identity);

                fixture
                    .get_last_shift_calendar_pattern_auto_reordered_event_for(shift_calendar_identity)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
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
}
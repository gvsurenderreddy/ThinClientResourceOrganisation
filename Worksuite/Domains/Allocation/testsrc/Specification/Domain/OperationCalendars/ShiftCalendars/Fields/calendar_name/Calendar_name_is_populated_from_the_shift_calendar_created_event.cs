using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Created;
using WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Fields.calendar_name {

    [TestClass]
    public class Calendar_name_is_populated_from_the_shift_calendar_created_event
                    : ASpecification<AllocatedSupplyTestBootstrapper> {

        [TestMethod]
        public void calendar_name_is_populated_from_a_shift_caledar_created_event () {

            var shift_calendar_created_event = fixture.create_event();

            fixture.event_handler.handle( shift_calendar_created_event );

            fixture
                .shift_caledar_for( shift_calendar_created_event )
                .Match(

                    has_value:
                        shift_calendar => shift_calendar.calendar_name.Should().Be( shift_calendar_created_event.calendar_name ),

                    nothing:
                        () => Assert.Fail("ShiftCalendar was not found")
                );
        }

        protected override void test_setup () {
            base.test_setup();
            fixture = new ShiftCalendarCreatedFixture();
        }

        private ShiftCalendarCreatedFixture fixture;

    }
}
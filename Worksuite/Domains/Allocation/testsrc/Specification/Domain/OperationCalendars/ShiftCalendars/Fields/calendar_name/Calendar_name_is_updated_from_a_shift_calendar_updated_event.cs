using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Updated;
using WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Fields.calendar_name {

    [TestClass]
    public class Calendar_name_is_updated_from_a_shift_calendar_updated_event 
                    : ASpecification<AllocatedSupplyTestBootstrapper> {

        [TestMethod]
        public void calendar_name_is_updated_from_a_shift_calendar_updated_event () {
            var shift_calendar_updated_event = fixture.create_event();
                shift_calendar_updated_event.calendar_name += "aass";

            fixture.event_handler.handle( shift_calendar_updated_event );

            fixture.shift_calendar.calendar_name.Should().Be( shift_calendar_updated_event.calendar_name );
        }
        
        protected override void test_setup () {
            base.test_setup();
            fixture = new ShiftCalendarUpdatedFixture();
        }

        private ShiftCalendarUpdatedFixture fixture;

    }
}
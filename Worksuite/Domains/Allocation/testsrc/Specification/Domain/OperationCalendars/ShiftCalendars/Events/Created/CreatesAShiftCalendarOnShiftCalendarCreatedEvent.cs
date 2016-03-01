using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Created {

    [TestClass]
    public class CreatesAShiftCalendarOnShiftCalendarCreatedEvent 
                    : ASpecification<AllocatedSupplyTestBootstrapper> {

        // done: creates the shift calendar
        // done: changes are commited

        [TestMethod]
        public void creates_the_shift_calendar () {
            
            fixture.event_handler.handle( fixture.create_event() );

            fixture.all_shift_calendars.Count().Should().Be( 1 );
        }

        [TestMethod]
        public void changes_are_commited () {
            
            fixture.event_handler.handle( fixture.create_event() );

            fixture.changes_were_commited().Should().BeTrue();
        }

        protected override void test_setup () {
            base.test_setup();
            fixture = new ShiftCalendarCreatedFixture();
        }

        private ShiftCalendarCreatedFixture fixture;

    }
}
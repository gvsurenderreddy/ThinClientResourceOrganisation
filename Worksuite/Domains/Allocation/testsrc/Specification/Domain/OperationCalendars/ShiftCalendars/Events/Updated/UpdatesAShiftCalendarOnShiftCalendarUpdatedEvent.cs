using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Updated {

    [TestClass]
    public class UpdatesAShiftCalendarOnShiftCalendarUpdatedEvent
                    : ASpecification<AllocatedSupplyTestBootstrapper> {
        
        [TestMethod]
        public void changes_are_commited () {
            
            fixture.event_handler.handle( fixture.create_event() );

            fixture.changes_were_commited().Should().BeTrue();
        }


        protected override void test_setup () {
            base.test_setup();
            fixture = new ShiftCalendarUpdatedFixture();
        }

        private ShiftCalendarUpdatedFixture fixture; 
    }
}
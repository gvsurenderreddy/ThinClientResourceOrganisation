using FluentAssertions;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.Events.Created {

    [TestClass]
    public class CreatesAnOperationCalendarOnOperationsCalendarCreatedEvent
                    : ASpecification<AllocatedSupplyTestBootstrapper> {

        [TestMethod]
        public void creates_the_operation_calendar () {
           
            fixture.event_handler.handle( fixture.create_event() );

            fixture.all_operation_calendars.Count().Should().Be( 1 );
        }

        [TestMethod]
        public void changes_are_committed () {

            fixture.event_handler.handle( fixture.create_event() );

            fixture.changes_were_commited( ).Should().BeTrue();
        }

        protected override void test_setup () {
            base.test_setup();

            fixture = new OperationCalendarCreatedFixture();
        }

        private OperationCalendarCreatedFixture fixture;
    }
}
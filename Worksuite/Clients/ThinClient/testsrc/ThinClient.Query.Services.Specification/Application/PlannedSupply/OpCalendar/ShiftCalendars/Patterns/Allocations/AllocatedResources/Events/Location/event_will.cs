using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Events.Location
{
    [TestClass]
    public class event_will : LocationUpdatedSpecification
    {

        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.event_handler.handle(create_event);

           Assert.AreEqual(true,fixture.changes_were_commited()); 
        }

        [TestMethod]
        public void update_the_location_of_any_associated_employee_views_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Where(ev => ev.location_id == the_event.id)
                                        .Do(ev => Assert.IsTrue(ev.location == the_event.description));
        }
    }
}

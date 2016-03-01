using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Events.JobTitle
{
    [TestClass]
    public class event_will : JobTitleUpdatedSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.event_handler.handle(create_event);

          Assert.AreEqual(true, fixture.changes_were_commited());
        }

        [TestMethod]
        public void update_the_jobtitle_of_any_associated_employee_views_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Where(ev => ev.job_title_id == the_event.id)

           .Do(ev => Assert.IsTrue(ev.job_title == the_event.description));
        }
    }
}

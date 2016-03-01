
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.JobTitleUpdated
{
    [TestClass]
    public class event_handler_will : JobTitleUpdatedEventSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {

            fixture.event_handler.handle(fixture.simulate_event());

            fixture.changes_were_commited().Should().BeTrue();
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

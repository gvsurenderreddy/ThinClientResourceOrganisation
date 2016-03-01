using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeRemoved
{
    [TestClass]
    public class event_handler_will: EmployeeRemovedEventSpecification
    {

        [TestMethod]
        public void remove_an_employee_view_from_the_repository_when_triggered()
        {

            fixture.event_handler.handle(fixture.simulate_event());
            
            fixture.all_employee_views.Count().Should().Be(0);
        }

        [TestMethod]
        public void commit_changes_when_triggered()
        {

            fixture.event_handler.handle(fixture.simulate_event());

            fixture.changes_were_commited().Should().BeTrue();
        }
    }
}

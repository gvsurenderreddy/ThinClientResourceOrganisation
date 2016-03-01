using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeePersonalDetailsUpdated
{
    [TestClass]
    public class event_handler_will : EmployeePersonalDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {

            fixture.event_handler.handle(fixture.simulate_event());

            fixture.changes_were_commited().Should().BeTrue();
        }

        [TestMethod]
        public void update_the_employee_forename_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev=>ev.employee_id == the_event.employee_id)
                                        .forename
                                        .Should()
                                        .Be(the_event.forename);
        }

        [TestMethod]
        public void update_the_employee_surname_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id)
                                        .surname
                                        .Should()
                                        .Be(the_event.surname);
        }
    }
}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Events.Personal
{
    [TestClass]
    public class event_handler_will : EmployeePersonalDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.employee_personal_details_event_updated.handle(create_event);

            Assert.AreEqual(true, fixture.changes_were_commited());
        }

        [TestMethod]
        public void update_the_employee_forename_of_an_employee_view_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.employee_personal_details_event_updated.handle(create_event);

            var forename = fixture.all_employee_views.Single(x => x.employee_id == create_event.employee_id).forename;

            Assert.AreEqual(create_event.forename, forename);

        }

        [TestMethod]
        public void update_the_employee_surname_of_an_employee_view_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.employee_personal_details_event_updated.handle(create_event);

            var surname = fixture.all_employee_views.Single(x => x.employee_id == create_event.employee_id).surname;

            Assert.AreEqual(create_event.surname, surname);

        }

    }
}

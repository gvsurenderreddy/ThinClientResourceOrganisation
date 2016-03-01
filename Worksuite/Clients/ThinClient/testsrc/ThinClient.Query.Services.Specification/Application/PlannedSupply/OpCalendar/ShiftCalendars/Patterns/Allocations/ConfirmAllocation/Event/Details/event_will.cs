using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Details;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.Events.EmployeeDetails
{
    [TestClass]
    public class event_will : EmployeeEmploymentDetailsUpdatedSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var create_event = fixture.simulate_event();

            fixture.event_handler.handle(create_event);

            Assert.AreEqual(true, fixture.changes_were_commited());
        }

        [TestMethod]
        public void update_the_employee_ref_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);
            var employee_reference =
                fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id).employee_reference;

            Assert.AreEqual(the_event.employee_reference, employee_reference);
        }

        [TestMethod]
        public void update_the_employee_job_title_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            var job_title = fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id).job_title;

            Assert .AreEqual(the_event.job_title_description,job_title);
        }

        [TestMethod]
        public void update_the_employee_job_title_id_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            var job_title_id = fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id).job_title_id;

            Assert.AreEqual(the_event.job_title_id,job_title_id);
        }

        [TestMethod]
        public void update_the_employee_location_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            var location = fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id).location;

            Assert.AreEqual(the_event.location_description,location);
        }

        [TestMethod]
        public void update_the_employee_location_id_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            var location_id = fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id).location_id;

            Assert.AreEqual(the_event.location_id,location_id);
        }
    }
}

using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeEmploymentDetailsUpdated
{
    [TestClass]
    public class event_handler_will : EmployeeEmploymentDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {

            fixture.event_handler.handle(fixture.simulate_event());

            fixture.changes_were_commited().Should().BeTrue();
        }

        [TestMethod]
        public void update_the_employee_ref_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev=>ev.employee_id == the_event.employee_id)
                                        .employee_reference
                                        .Should()
                                        .Be(the_event.employee_reference);
        }

        [TestMethod]
        public void update_the_employee_job_title_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id)
                                        .job_title
                                        .Should()
                                        .Be(the_event.job_title_description);
        }

        [TestMethod]
        public void update_the_employee_job_title_id_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id)
                                        .job_title_id
                                        .Should()
                                        .Be(the_event.job_title_id);
        }

        [TestMethod]
        public void update_the_employee_location_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id)
                                        .location
                                        .Should()
                                        .Be(the_event.location_description);
        }

        [TestMethod]
        public void update_the_employee_location_id_of_an_employee_view_when_triggered()
        {
            var the_event = fixture.simulate_event();

            fixture.event_handler.handle(the_event);

            fixture.all_employee_views.Single(ev => ev.employee_id == the_event.employee_id)
                                        .location_id
                                        .Should()
                                        .Be(the_event.location_id);
        }
    }
}

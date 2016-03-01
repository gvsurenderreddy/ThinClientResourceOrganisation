using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Events;

namespace WTS.WorkSuite.HR.Query.Domain.EmployeeView.Events.EmployeeCreated
{
    [TestClass]
    public class event_handler_will: EmployeeCreatedEventSpecification
    {

        [TestMethod]
        public void add_an_employee_view_to_the_repository_when_triggered()
        {

            fixture.event_handler.handle(new EmployeeCreatedEvent());
            
            fixture.all_employee_views.Count().Should().Be(1);
        }

        [TestMethod]
        public void commit_changes_when_triggered()
        {

            fixture.event_handler.handle(new EmployeeCreatedEvent());

            fixture.changes_were_commited().Should().BeTrue();
        }

        [TestMethod]
        public void correctly_map_employee_id_field_when_triggered()
        {
            var event_data = fixture.simulate_event();

            fixture.event_handler.handle(event_data);

            fixture.all_employee_views.Count(ev => ev.employee_id == event_data.employee_id).Should().Be(1);
        }

        [TestMethod]
        public void correctly_map_employee_forename_field_when_triggered()
        {
            var event_data = fixture.simulate_event();

            fixture.event_handler.handle(event_data);

            fixture.all_employee_views.Count(ev => ev.forename == event_data.forename).Should().Be(1);
        }

        [TestMethod]
        public void correctly_map_employee_surname_field_when_triggered()
        {
            var event_data = fixture.simulate_event();

            fixture.event_handler.handle(event_data);

            fixture.all_employee_views.Count(ev => ev.surname == event_data.surname).Should().Be(1);
        }

        [TestMethod]
        public void correctly_map_employee_ref_field_when_triggered()
        {
            var event_data = fixture.simulate_event();

            fixture.event_handler.handle(event_data);

            fixture.all_employee_views.Count(ev => ev.employee_reference == event_data.employee_reference).Should().Be(1);
        }
    }
}

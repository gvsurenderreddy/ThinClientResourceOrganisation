using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Create
{
    [TestClass]
    public class event_will : EmployeeCreateEventSpecification
    {
        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var create_event = fixture.simulat_event();

            fixture.create_event_when_employee_created.handle(create_event);

            Assert.AreEqual(true, fixture.Changes_were_commited());
        }

        [TestMethod]
        public void add_an_employee_view_to_the_repository_when_triggered()
        {
            var create_event = fixture.simulat_event();

            fixture.create_event_when_employee_created.handle(create_event);

            Assert.AreEqual(1,fixture.all_employee_table_views.Count());
        }

        [TestMethod]
        public void correctly_map_employee_id_field_when_triggered()
        {
            var create_event = fixture.simulat_event();

            fixture.create_event_when_employee_created.handle(create_event);

            var employee_id_count = fixture.all_employee_table_views.Count(ev => ev.employee_id == create_event.employee_id);

            Assert.AreEqual(1,employee_id_count);
        }

        [TestMethod]
        public void correctly_map_employee_name_field_when_triggered()
        {
            var create_event = fixture.simulat_event();

            fixture.create_event_when_employee_created.handle(create_event);

            var employee_forname = fixture.all_employee_table_views.Count(ev => ev.name == create_event.forename +" "+ create_event.surname);

            Assert.AreEqual(1, employee_forname);
        }
     
        [TestMethod]
        public void correctly_map_employee_ref_field_when_triggered()
        {
            var event_data = fixture.simulat_event();

            fixture.create_event_when_employee_created.handle(event_data);

            var employee_reference_count = fixture.all_employee_table_views.Count(ev => ev.employee_reference == event_data.employee_reference);

            Assert.AreEqual(1, employee_reference_count);
        }
    }
}

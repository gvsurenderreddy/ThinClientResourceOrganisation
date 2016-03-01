using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Remove
{
    [TestClass]
    public class event_will : EmployeeRemoveSpecification
    {
        [TestMethod]
        public void remove_an_employee_view_from_the_repository_when_triggered()
        {
            var employee_removed_event = fixture.simulat_event();
            
            fixture.event_handler.handle(employee_removed_event);

           Assert.AreEqual(0, fixture.all_employee_views.Count());
        }

        [TestMethod]
        public void commit_changes_when_triggered()
        {
            var employee_removed_event = fixture.simulat_event();

            fixture.event_handler.handle(employee_removed_event);

            Assert.AreEqual(true,fixture.changes_were_commited());
        }

    }
}

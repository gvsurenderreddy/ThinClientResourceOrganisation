using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields.emp_ref
{
    [TestClass]
    public class merge_will : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void return_employee_reference()
        {
            fixture.add_employee().employee_id(1).employee_reference("emp_1");
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var response = fixture.result;
            var employee_reference = response.ElementAt(0).employee_reference;

            Assert.AreEqual("emp_1", employee_reference);
        }
    }
}

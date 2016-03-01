using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields.emp_ref
{
    [TestClass]
   public class employee_reference_will : GetSelectedAllocatableResourceSpecification
    {
        [TestMethod]
        public void return_employee_reference()
        {
            fixture.add_employee().employee_id(1).employee_reference("employee_reference");

            fixture.execute();

            Assert.AreEqual("employee_reference", fixture.result.employee_reference);

        }
    }
}

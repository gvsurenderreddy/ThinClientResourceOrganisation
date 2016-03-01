using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields.emp_id
{
    [TestClass]
    public class employee_id_will : GetSelectedAllocatableResourceSpecification
    {
        [TestMethod]
        public void return_employee_id()
        {
            fixture.add_employee().employee_id(1);

            fixture.execute();

            Assert.AreEqual(1, fixture.result.employee_id);
        }
    }
}

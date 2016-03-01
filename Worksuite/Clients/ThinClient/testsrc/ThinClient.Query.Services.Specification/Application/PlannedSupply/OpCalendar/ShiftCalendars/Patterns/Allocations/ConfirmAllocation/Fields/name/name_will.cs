using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields.name
{
    [TestClass]
    public class forename_will : GetSelectedAllocatableResourceSpecification
    {
        [TestMethod]
        public void return_forename()
        {
            fixture.add_employee().employee_id(1).name("full name");

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("full name", result.name);
        }
    }
}

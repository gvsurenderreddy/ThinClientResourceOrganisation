using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields.Surname
{
    [TestClass]
    public class merge_will : GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void return_surname()
        {
            fixture.add_employee().employee_id(1).surname("surname");

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("surname", result.ElementAt(0).surname);
        }
    }
}

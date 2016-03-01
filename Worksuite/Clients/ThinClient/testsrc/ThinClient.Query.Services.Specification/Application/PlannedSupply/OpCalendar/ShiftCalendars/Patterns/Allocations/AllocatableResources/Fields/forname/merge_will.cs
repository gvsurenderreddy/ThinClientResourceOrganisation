using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields.forname
{
    [TestClass]
    public class merge_will:GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void return_forname()
        {
            fixture.add_employee().employee_id(1).forname("forname");
            
            fixture.execute();
            var employee_with_allocation = fixture.result;

            Assert.AreEqual("forname",employee_with_allocation.ElementAt(0).forename);
        }
    }
}

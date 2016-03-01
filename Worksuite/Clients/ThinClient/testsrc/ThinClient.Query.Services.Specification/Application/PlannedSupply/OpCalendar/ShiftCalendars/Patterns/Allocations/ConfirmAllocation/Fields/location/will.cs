using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields.location
{
    [TestClass]
   public  class location_will :GetSelectedAllocatableResourceSpecification
    {
       [TestMethod]
       public void return_location()
       {
           fixture.add_employee().employee_id(1).location("Manchester");

           fixture.execute();
           var result = fixture.result;

           Assert.AreEqual("Manchester", result.location);
       }
    }
}

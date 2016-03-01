using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields.job
{
    [TestClass]
    public class job_will : GetSelectedAllocatableResourceSpecification
    {
        [TestMethod]
        public void return_job_title()
        {
            fixture.add_employee().employee_id(1).job_title("developer");

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("developer", result.job_title);
        }
    }
}

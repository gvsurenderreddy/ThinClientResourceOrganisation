using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields.Job
{
    [TestClass]
    public class merge_will : GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void return_job_title()
        {
            fixture.add_employee().employee_id(1).job_title("developer");

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("developer", result.ElementAt(0).job_title);
        }
    }
}

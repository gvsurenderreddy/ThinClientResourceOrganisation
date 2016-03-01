using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields.job_title
{
    [TestClass]
    public class merge_will : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void should_return_job_title()
        {
            fixture.add_employee().employee_id(1).job_title("developer");
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var shift_calendar_pattern_resources = fixture.result;
            var job_title = shift_calendar_pattern_resources.ElementAt(0).job_title;

            Assert.AreEqual("developer",job_title);
        }
    }
}

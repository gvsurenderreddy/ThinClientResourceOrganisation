using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields.location
{
    [TestClass]
    public class merge_will  : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void should_return_location()
        {
            fixture.add_employee().employee_id(1).location("Manchester");
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var shift_calendar_pattern_resources = fixture.result;
            var location = shift_calendar_pattern_resources.ElementAt(0).location;

            Assert.AreEqual("Manchester", location);
        }
    }
}

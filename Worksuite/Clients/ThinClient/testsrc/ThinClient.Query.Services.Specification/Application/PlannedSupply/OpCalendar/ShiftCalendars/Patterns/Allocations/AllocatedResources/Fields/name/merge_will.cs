using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields.name
{
    [TestClass]
    public class merge_will : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void should_return_name()
        {
            fixture.add_employee().employee_id(1).name("Full Name");
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("Full Name",result.ElementAt(0).name);
        }

        [TestMethod]
        public void return_blank()
        {
            fixture.add_employee().employee_id(1);
            fixture.add_resource().employee_id(1);

          
            fixture.execute();
            var result = fixture.result;
            var name = result.ElementAt(0).name;

            Assert.AreEqual(null, name);
        }
    }
}

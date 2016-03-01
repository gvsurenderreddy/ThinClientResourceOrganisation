using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItemQuery
{
    [TestClass]
    public class should_return : GetAllocatableResourcesTableItemSpecification
    {
        [TestMethod]
        public void should_return_employee_id()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1);

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).employee_id, find_employeetable_view_builder.entity.employee_id);
        }

        [TestMethod]
        public void should_return_employee_forname()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1).forname("forname");

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).forename, find_employeetable_view_builder.entity.forename);
        }

        [TestMethod]
        public void should_return_employee_surname()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1).surname("surname");

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).surname, find_employeetable_view_builder.entity.surname);
        }

        [TestMethod]
        public void should_return_employee_ref()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1).employee_reference("reference");

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).employee_reference, find_employeetable_view_builder.entity.employee_reference);
        }

        [TestMethod]
        public void should_return_job_title()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1).job_title("job");

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).job_title, find_employeetable_view_builder.entity.job_title);
        }

        [TestMethod]
        public void should_return_location()
        {
            var find_employeetable_view_builder = fixture.add().employee_id(1).location("location");

            fixture.execute_query();

            Assert.AreEqual(fixture.response.ElementAt(0).location, find_employeetable_view_builder.entity.location);
        }

        [TestMethod]
        public void should_return_employees()
        {
            fixture.add().employee_id(1);
            fixture.add().employee_id(2);
            fixture.add().employee_id(3);
            fixture.add().employee_id(4);

            fixture.execute_query();

            Assert.AreEqual(4, fixture.response.Count());
        }
    }
}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.ListItemQuery
{
    [TestClass]
    public class should_return_allocated_resources_list_item : AllocatedResourcesListItemSpecification
    {
        [TestMethod]
        public void should_return_employee_id()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1);

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).employee_id, find_allocatable_resources_table_view_builder.entity.employee_id);
        }

        [TestMethod]
        public void should_return_employee_reference()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1).employee_reference("emp_1");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).employee_reference, find_allocatable_resources_table_view_builder.entity.employee_reference);
        }

        [TestMethod]
        public void should_return_job_title()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1).job_title("developer");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).job_title, find_allocatable_resources_table_view_builder.entity.job_title);
        }

        [TestMethod]
        public void should_return_location()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1).location("Manchester");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).location, find_allocatable_resources_table_view_builder.entity.location);
        }

        [TestMethod]
        public void should_return_name()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1).name("Full Name");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).name, find_allocatable_resources_table_view_builder.entity.name);
        }

        [TestMethod]
        public void should_return_multiple_employee()
        {
             fixture.add().employee_id(1);
             fixture.add().employee_id(2);
             fixture.add().employee_id(3);

            fixture.execute_query();


            Assert.AreEqual(3,fixture.response.Count());
        }
    }
}

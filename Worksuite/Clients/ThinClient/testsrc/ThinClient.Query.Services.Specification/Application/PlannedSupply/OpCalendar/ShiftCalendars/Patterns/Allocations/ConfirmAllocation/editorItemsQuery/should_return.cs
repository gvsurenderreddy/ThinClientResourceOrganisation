using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.editorItemsQuery
{
    [TestClass]
    public class should_return : GetAllocationRequestDetailsEditorItemsSpecification
    {
        [TestMethod]
        public void employee_id()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_id(1);

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).employee_id, find_allocatable_resources_table_view_builder.entity.employee_id);
        }

        [TestMethod]
        public void employee_name()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().name("full name");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).name, find_allocatable_resources_table_view_builder.entity.name);
        }

        [TestMethod]
        public void employee_reference()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().employee_reference("employee_reference");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).employee_reference, find_allocatable_resources_table_view_builder.entity.employee_reference);
        }

        [TestMethod]
        public void employee_job_title()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().job_title("job_title");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).job_title, find_allocatable_resources_table_view_builder.entity.job_title);
        }

        [TestMethod]
        public void employee_location()
        {
            var find_allocatable_resources_table_view_builder = fixture.add().location("location");

            fixture.execute_query();


            Assert.AreEqual(fixture.response.ElementAt(0).location, find_allocatable_resources_table_view_builder.entity.location);
        }

        [TestMethod]
        public void number_of_employee()
        {
            fixture.add().employee_id(1);
            fixture.add().employee_id(2);
            fixture.add().employee_id(3);

            fixture.execute_query();


            Assert.AreEqual(3,fixture.response.Count());
        }
    }
}

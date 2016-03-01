using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields
{
    [TestClass]
    public class should_return_allocated_resources : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void should_return_single_employee()
        {
            fixture.add_employee().employee_id(1);
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var number_of_resources = fixture.result.Count();

            Assert.AreEqual(1, number_of_resources);
        }

        [TestMethod]
        public void should_return_some_employees()
        {

            fixture.add_employee().employee_id(2);
            fixture.add_resource().employee_id(2);

            fixture.add_employee().employee_id(3);
            fixture.add_resource().employee_id(3);

            fixture.add_employee().employee_id(4);
            fixture.add_resource().employee_id(4);

            fixture.add_resource().employee_id(5);

            fixture.execute();
            var number_of_resources = fixture.result.Count();

            Assert.AreEqual(3, number_of_resources);
        }

        [TestMethod]
        public void should_return_no_employees()
        {
            fixture.add_employee().employee_id(12);
            fixture.add_resource().employee_id(15);
            fixture.add_resource().employee_id(6);
            fixture.add_employee().employee_id(9);
            fixture.add_resource().employee_id(8);

            fixture.execute();
            var number_of_resources = fixture.result.Count();

            Assert.AreEqual(0, number_of_resources);
        }

        [TestMethod]
        public void no_resources_so_no_employees()
        {
            fixture.add_employee().employee_id(13);

            fixture.add_employee().employee_id(16);

            fixture.add_employee().employee_id(28);

            fixture.execute();
            var number_of_resources = fixture.result.Count();

            Assert.AreEqual(0, number_of_resources);
        }

        [TestMethod]
        public void results_ordered_by_created_date_descending()
        {
            fixture.add_resource().employee_id(1).date_time(new DateTime(2015, 1, 1, 0, 0, 0));
            fixture.add_employee().employee_id(1).name("created first");

            fixture.add_resource().employee_id(2).date_time(new DateTime(2015, 1, 1, 20, 0, 0));
            fixture.add_employee().employee_id(2).name("created last");

            fixture.add_resource().employee_id(3).date_time(new DateTime(2015, 1, 1, 10, 0, 0));
            fixture.add_employee().employee_id(3).name("created second");

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("created last", result.ElementAt(0).name);
            Assert.AreEqual("created second", result.ElementAt(1).name);
            Assert.AreEqual("created first", result.ElementAt(2).name);
        }
    }
}

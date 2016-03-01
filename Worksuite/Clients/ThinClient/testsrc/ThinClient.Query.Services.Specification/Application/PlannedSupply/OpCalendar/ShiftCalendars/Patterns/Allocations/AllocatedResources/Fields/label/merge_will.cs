using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Fields.label
{
    [TestClass]
    public class merge_will : AllocatedResourcesListViewSpecification
    {
        [TestMethod]
        public void return_single_resource_label()
        {
            fixture.add_employee().employee_id(1);
            fixture.add_resource().employee_id(1);

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("Resource 1", result.ElementAt(0).resource_label);
        }

        [TestMethod]
        public void return_multiple_resource_labels()
        {
            fixture.add_employee().employee_id(1);
            fixture.add_resource().employee_id(1).date_time(new DateTime(2010, 1, 1, 0, 0, 0));
            fixture.add_employee().employee_id(2);
            fixture.add_resource().employee_id(2).date_time(new DateTime(2012, 1, 1, 0, 0, 0));
            fixture.add_employee().employee_id(3);
            fixture.add_resource().employee_id(3).date_time(new DateTime(2014, 1, 1, 0, 0, 0));

            fixture.execute();
            var result = fixture.result;

            Assert.AreEqual("Resource 1", result.ElementAt(0).resource_label);
            Assert.AreEqual("Resource 2", result.ElementAt(1).resource_label);
            Assert.AreEqual("Resource 3", result.ElementAt(2).resource_label);
        }
       
    }
}

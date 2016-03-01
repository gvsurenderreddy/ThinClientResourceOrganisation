using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields.emp_id
{
    [TestClass]
    public class emp_id_will : GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void return_employee_id()
        {
            // Arrange
            fixture.add_employee().employee_id(1);

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(1, result.ElementAt(0).employee_id);
        }
    }
}

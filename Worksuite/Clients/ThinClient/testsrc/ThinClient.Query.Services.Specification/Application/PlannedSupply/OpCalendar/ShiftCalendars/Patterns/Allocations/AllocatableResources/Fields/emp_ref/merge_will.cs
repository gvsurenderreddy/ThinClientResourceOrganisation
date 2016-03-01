using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields.emp_ref
{
    [TestClass]
   public class merge_will : GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void return_emp_ref()
        {
            // Arrange
            fixture.add_employee().employee_id(1).employee_reference("ABC-123");

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual("ABC-123", result.ElementAt(0).employee_reference);
        }
    }
}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields
{
    [TestClass]
    public class should_return :GetAllocatableResourcesSpecification
    {
        [TestMethod]
        public void single_employees()
        {
            fixture.add_employee().employee_id(1);
            fixture.add_resources().employee_id(1);

            fixture.execute();
            var employee_with_allocation_result = fixture.result;

            Assert.AreEqual(1,employee_with_allocation_result.Count());
        }

        [TestMethod]
        public void allocated_resources()
        {
            // Arrange
            fixture.add_employee().employee_id(2);
            fixture.add_resources().employee_id(2);

            fixture.add_employee().employee_id(3);
            fixture.add_resources().employee_id(3);

            fixture.add_employee().employee_id(4);
            fixture.add_resources().employee_id(4);

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void unallocated_resources()
        {
            // Arrange
            fixture.add_employee().employee_id(2);
            fixture.add_employee().employee_id(3);
            fixture.add_employee().employee_id(4);

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void allocated_and_unallocated_resources()
        {
            // Arrange
            fixture.add_employee().employee_id(1);
            fixture.add_employee().employee_id(2);

            fixture.add_employee().employee_id(3);
            fixture.add_resources().employee_id(3);

            fixture.add_employee().employee_id(4);
            fixture.add_resources().employee_id(4);

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void zero_without_unallocated_resources()
        {
            // Arrange
            fixture.add_resources().employee_id(1);
            fixture.add_resources().employee_id(2);

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void in_surname_order()
        {
            // Arrange
            fixture.add_employee().employee_id(1).surname("C_surname");
            fixture.add_employee().employee_id(2).surname("A_Surname");
            fixture.add_employee().employee_id(3).surname("B_surname");

            // Act
            fixture.execute();
            var result = fixture.result;

            // Assert
            Assert.AreEqual(2, result.ElementAt(0).employee_id);
            Assert.AreEqual(3, result.ElementAt(1).employee_id);
            Assert.AreEqual(1, result.ElementAt(2).employee_id);
        }
    }
}

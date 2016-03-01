using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByCalendar
{
    [TestClass]
    public class should_return : GetResourceAllocationsSpecification
    {
        [TestMethod]
        public void single_resource_allocation()
        {
            // Arrange
            fixture.add_allocation_to_pattern_a();

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(1, response.Count());
        }

        [TestMethod]
        public void multiple_resource_allocation()
        {
            // Arrange
            fixture.add_allocation_to_pattern_a();
            fixture.add_allocation_to_pattern_a();
            fixture.add_allocation_to_pattern_a();

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(3, response.Count());
        }

        [TestMethod]
        public void multiple_resource_allocation_different_patterns()
        {
            // Arrange
            fixture.add_allocation_to_pattern_a();
            fixture.add_allocation_to_pattern_a();
            fixture.add_allocation_to_pattern_a();
            fixture.add_allocation_to_pattern_b();
            fixture.add_allocation_to_pattern_b();

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(5, response.Count());
        }

        [TestMethod]
        public void zero_resource_allocations()
        {
            // Arrange

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(0, response.Count());
        }
    }
}

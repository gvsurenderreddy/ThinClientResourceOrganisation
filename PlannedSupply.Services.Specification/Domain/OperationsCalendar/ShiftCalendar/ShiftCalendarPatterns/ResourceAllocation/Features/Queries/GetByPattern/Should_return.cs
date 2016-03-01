using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByPattern;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocations.Queries.GetResourceAllocationsByShiftCalendarPattern
{
    [TestClass]
    public class should_return : GetResourceAllocationsSpecification
    {
        [TestMethod]
        public void single_resource_allocation()
        {
            // Arrange
            fixture.add_resource_allocation();

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
            fixture.add_resource_allocation();
            fixture.add_resource_allocation();
            fixture.add_resource_allocation();

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(3, response.Count());
        }

        [TestMethod]
        public void zero_resource_allocation()
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

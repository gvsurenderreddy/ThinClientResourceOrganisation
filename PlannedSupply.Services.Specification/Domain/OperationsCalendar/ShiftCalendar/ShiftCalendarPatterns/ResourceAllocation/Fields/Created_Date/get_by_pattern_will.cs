using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByPattern;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Fields.Created_Date
{
    [TestClass]
    public class get_by_pattern_will : GetResourceAllocationsSpecification
    {
        [TestMethod]
        public void return_correct_date()
        {
            // Arrange
            var theDatetoTest = new DateTime(2015, 02, 03, 14, 42, 16);

            fixture.add_resource_allocation()
                            .created_date(theDatetoTest);

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(theDatetoTest, response.First().created_date);
        }
    }
}

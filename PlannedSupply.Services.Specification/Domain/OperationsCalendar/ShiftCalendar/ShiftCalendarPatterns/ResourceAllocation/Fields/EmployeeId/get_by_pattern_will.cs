using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByPattern;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Fields.EmployeeId
{
    [TestClass]
    public class get_by_pattern_will : GetResourceAllocationsSpecification
    {
        [TestMethod]
        public void return_correct_employee_id()
        {
            // Arrange

            int employee_id_to_test = 25;

            fixture.add_resource_allocation()
                                .employee(new EmployeePlannedSupply {employee_id = employee_id_to_test});

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(employee_id_to_test, response.First().employee_id);
        }
    }
}

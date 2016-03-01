using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByCalendar;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Fields.EmployeeId
{
    [TestClass]
    public class get_by_calendar_will : GetResourceAllocationsSpecification
    {
        [TestMethod]
        public void return_correct_employee_id()
        {
            // Arrange

            int employee_id_to_test = 25;

            fixture.add_allocation_to_pattern_a()
                                .employee(new EmployeePlannedSupply {employee_id = employee_id_to_test});

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(employee_id_to_test, response.First().employee_id);
        }

        [TestMethod]
        public void return_multiple_correct_employee_id()
        {
            // Arrange
            int employee_id_pattern_a = 10;
            int employee_id_pattern_b = 20;

            fixture.add_allocation_to_pattern_a()
                                .employee(new EmployeePlannedSupply { employee_id = employee_id_pattern_a });

            fixture.add_allocation_to_pattern_b()
                                .employee(new EmployeePlannedSupply { employee_id = employee_id_pattern_b });

            int pattern_a_id = fixture._shift_calendar_pattern_a.id;
            int pattern_b_id = fixture._shift_calendar_pattern_b.id;

            // Act
            fixture.execute_query();
            var response = fixture.response.result;

            // Assert
            Assert.AreEqual(employee_id_pattern_a, response.Single(r => r.shift_calendar_pattern_id == pattern_a_id).employee_id);
            Assert.AreEqual(employee_id_pattern_b, response.Single(r => r.shift_calendar_pattern_id == pattern_b_id).employee_id);
        }
    }
}

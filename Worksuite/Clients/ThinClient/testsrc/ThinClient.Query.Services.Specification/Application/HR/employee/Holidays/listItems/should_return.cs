using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems
{
    [TestClass]
    public class should_return : GetHolidayListItemsSpecification
    {
        [TestMethod]
        public void single_holiday()
        {
            // Arrange
            var employee_request = new EmployeeIdentity {employee_id = 1};
            fixture.set_request(employee_request);

            fixture.add().employee_id(employee_request.employee_id);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void multiple_holidays()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void no_holidays()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void correct_employees_holidays()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 2 };
            fixture.set_request(employee_request);

            // Holiday for a different emp
            fixture.add().employee_id(1);

            // 4 holidays for requested emp
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);

            // 2 holidyas for another emp
            fixture.add().employee_id(3);
            fixture.add().employee_id(3);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void correct_employee_id()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture.add().employee_id(0);
            fixture.add().employee_id(99);

            // Request employee
            fixture.add().employee_id(employee_request.employee_id);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(employee_request.employee_id, result.First().employee_id);
        }

        [TestMethod]
        public void correct_holiday_date()
        {
            // Arrange
            var holiday_date_output = "2 Mar 2015";
            var holiday_date = new DateTime(2015,3,2);

            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .holiday_date(holiday_date)
                ;

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(holiday_date_output, result.First().holiday_date_display);
        }

        [TestMethod]
        public void in_chronological_order()
        {
            // Arrange
            var date_1 = new DateTime(2000, 3, 2);
            var date_1_output = "2 Mar 2000";

            var date_2 = new DateTime(2010, 11, 8);
            var date_2_output = "8 Nov 2010";

            var date_3 = new DateTime(2014, 1, 24);
            var date_3_output = "24 Jan 2014";

            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .holiday_date(date_2)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .holiday_date(date_1)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .holiday_date(date_3)
                ;

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(date_1_output, result.ElementAt(0).holiday_date_display);
            Assert.AreEqual(date_2_output, result.ElementAt(1).holiday_date_display);
            Assert.AreEqual(date_3_output, result.ElementAt(2).holiday_date_display);
        }
    }
}

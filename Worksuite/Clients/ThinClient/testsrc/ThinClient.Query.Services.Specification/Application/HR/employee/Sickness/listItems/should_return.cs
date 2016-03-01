using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems
{
    [TestClass]
    public class should_return : GetSicknessListItemsSpecification
    {
        [TestMethod]
        public void single_sickness()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture.add().employee_id(employee_request.employee_id);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void multiple_sickness()
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
        public void no_sickness()
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
        public void correct_employees_sickness()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 2 };
            fixture.set_request(employee_request);

            // Sickness for a different emp
            fixture.add().employee_id(1);

            // 4 sickness for requested emp
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);

            // 2 sickness for another emp
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
        public void correct_sickness_date()
        {
            // Arrange
            var sickness_date_output = "13 Apr 2015";
            var sickness_date = new DateTime(2015, 4, 13);

            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .sickness_date(sickness_date)
                ;

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(sickness_date_output, result.First().sickness_date_display);
        }

        [TestMethod]
        public void in_chronological_order()
        { // Arrange
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
                .sickness_date(date_2)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .sickness_date(date_1)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .sickness_date(date_3)
                ;

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(date_1_output, result.ElementAt(0).sickness_date_display);
            Assert.AreEqual(date_2_output, result.ElementAt(1).sickness_date_display);
            Assert.AreEqual(date_3_output, result.ElementAt(2).sickness_date_display);
        }
    }
}

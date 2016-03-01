using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules
{
    [TestClass]
    public class should_return : GetEmployeeViewScheduleTableItemsSpecification
    {
        [TestMethod]
        public void should_return_employee_id()
        {
            var request = new EmployeeIdentity {employee_id = 1};

            fixture.add().employee_id(0);
            fixture.add().employee_id(2);

            fixture.set_request(request);
            fixture.add().employee_id(request.employee_id);
            fixture.execute_query();

           Assert.AreEqual(fixture.response.result.ElementAt(0).employee_id, request.employee_id);
        }

        [TestMethod]
        public void should_return_employee_display_date()
        {
            var request = new EmployeeIdentity { employee_id = 1 };
            var display_date = new DateTime(2008, 03, 12);

            var display_date_output = "12 Mar 2008";

            fixture.set_request(request);
            fixture.add().employee_id(request.employee_id).display_date(display_date);
            fixture.execute_query();

            Assert.AreEqual(fixture.response.result.ElementAt(0).employee_id, request.employee_id);
            Assert.AreEqual(fixture.response.result.ElementAt(0).display_date, display_date_output);
        }

        [TestMethod]
        public void number_of_table_rows_to_be_displayed_should_be_zero_if_employee_was_not_part_publish_process()
        {
            var request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(request);
            fixture.execute_query();

            Assert.AreEqual(fixture.response.result.Count(), 0);
        }

        [TestMethod]
        public void should_dates_with_correct_report_format()
        {
            var request = new EmployeeIdentity { employee_id = 1 };
            var display_date = new DateTime(2009, 1, 10);

            const string correct_format = "10 Jan 2009";

            fixture.set_request(request);
            fixture.add().employee_id(request.employee_id).display_date(display_date);
            fixture.execute_query();

            Assert.AreEqual(fixture.response.result.ElementAt(0).employee_id, request.employee_id);
            Assert.AreEqual(fixture.response.result.ElementAt(0).display_date, correct_format);
        }

        [TestMethod]
        public void should_fail_if_date_range_does_not_match_the_report_format_specified()
        {
            var request = new EmployeeIdentity { employee_id = 1 };
            var display_date = new DateTime(2009, 1, 1);

            fixture.set_request(request);
            fixture.add().employee_id(request.employee_id).display_date(display_date);
            fixture.execute_query();

            Assert.AreEqual(fixture.response.result.ElementAt(0).employee_id, request.employee_id);

            string element_at = fixture.response.result.ElementAt(0).display_date;
            Assert.AreNotEqual(element_at, "2 jan 2009");
        }
        
        [TestMethod]
        public void correct_employees_dates()
        {
            // Arrange
            var employee_request = new EmployeeIdentity { employee_id = 2 };
            fixture.set_request(employee_request);

            // Display Date for a different emp
            fixture.add().employee_id(1);

            // 4 display dates for requested emp
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);
            fixture.add().employee_id(employee_request.employee_id);

            // 2 Dates for another emp
            fixture.add().employee_id(3);
            fixture.add().employee_id(3);

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void in_chronological_order()
        {
            // Arrange
            var date_1 = new DateTime(2015, 3, 2);
            var date_1_output = "2 Mar 2015";

            var date_2 = new DateTime(2015, 11, 8);
            var date_2_output = "8 Nov 2015";

            var date_3 = new DateTime(2015, 1, 24);
            var date_3_output = "24 Jan 2015";

            var employee_request = new EmployeeIdentity { employee_id = 1 };
            fixture.set_request(employee_request);

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .display_date(date_2)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .display_date(date_1)
                ;

            fixture
                .add()
                .employee_id(employee_request.employee_id)
                .display_date(date_3)
                ;

            // Act
            fixture.execute_query();
            var result = fixture.response.result;

            // Assert
            Assert.AreEqual(date_3_output, result.ElementAt(0).display_date);
            Assert.AreEqual(date_1_output, result.ElementAt(1).display_date);
            Assert.AreEqual(date_2_output, result.ElementAt(2).display_date);
        }

    }
}

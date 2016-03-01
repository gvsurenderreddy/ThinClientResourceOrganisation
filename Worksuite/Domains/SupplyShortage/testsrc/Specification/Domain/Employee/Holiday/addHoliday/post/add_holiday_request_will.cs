using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.addHoliday.post
{
    [TestClass]
    public class add_holiday_request_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void return_correct_employee_id()
        {
            // Arrange with a valid holiday request
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(3)
                                .set_day("1")
                                .set_month("1")
                                .set_year("1900")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.employee_id, response.result.employee_id);
        }

        [TestMethod]
        public void return_correct_date_when_non_numeric_month()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("15")
                                .set_month("4")
                                .set_year("2015")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.holiday_date.to_date_time(), response.result.holiday_date);
        }

        [TestMethod]
        public void return_correct_date()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("31")
                                .set_month("dec")
                                .set_year("2012")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.holiday_date.to_date_time(), response.result.holiday_date);
        }

        [TestMethod]
        public void return_invalid_date_status()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("900")
                                .set_month("dec")
                                .set_year("2012")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(
                    typeof(AddHolidayRequestHandlerStatuses.InvalidHolidayDate),
                    response.service_statuses.Single(s => s.GetType() == typeof(AddHolidayRequestHandlerStatuses.InvalidHolidayDate)).GetType()
                    );
        }

        [TestMethod]
        public void generate_holiday_created_event()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(4)
                                .set_day("31")
                                .set_month("12")
                                .set_year("2020")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();
            var holiday_created_event = fixture.get_holiday_created_event();

            // Assert
            Assert.IsNotNull(holiday_created_event);
            Assert.AreEqual(fixture.request.employee_id, holiday_created_event.employee_id);
            Assert.AreEqual(fixture.request.holiday_date.to_date_time(), holiday_created_event.holiday_date);
        }

        [TestMethod]
        public void return_invalid_date_status_when_null()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(
                    typeof(AddHolidayRequestHandlerStatuses.InvalidHolidayDate),
                    response.service_statuses.Single(s => s.GetType() == typeof(AddHolidayRequestHandlerStatuses.InvalidHolidayDate)).GetType()
                    );
        }

        public void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeHolidayRequestHandlerFixture>();
        }

        private AddEmployeeHolidayRequestHandlerFixture fixture;
        public AddHolidayResponse response { get; private set; }

    }
}

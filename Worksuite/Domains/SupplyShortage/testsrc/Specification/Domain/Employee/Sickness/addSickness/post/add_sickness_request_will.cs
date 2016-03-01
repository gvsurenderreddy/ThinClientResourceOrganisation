using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.addSickness.post
{
    [TestClass]
    public class add_sickness_request_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void return_correct_employee_id()
        {
            // Arrange with a valid sickness request
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("1")
                                .set_month("1")
                                .set_year("2015")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.employee_id, response.result.employee_id);
        }

        [TestMethod]
        public void return_correct_sickness_date_when_non_numeric_month()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("20")
                                .set_month("5")
                                .set_year("2015")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.sickness_date.to_date_time(), response.result.sickness_date);
        }

        [TestMethod]
        public void return_correct_sickness_date()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("15")
                                .set_month("mar")
                                .set_year("2015")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.sickness_date.to_date_time(), response.result.sickness_date);
        }

        [TestMethod]
        public void return_invalid_sickness_date_status()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                                .request_builder
                                .set_employee_id(1)
                                .set_day("30")
                                .set_month("feb")
                                .set_year("2012")
                                .build_request()
                                ;

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(
                    typeof(AddSicknessRequestHandlerStatuses.InvalidSicknessDate),
                    response.service_statuses.Single(s => s.GetType() == typeof(AddSicknessRequestHandlerStatuses.InvalidSicknessDate)).GetType()
                    );
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
                    typeof(AddSicknessRequestHandlerStatuses.InvalidSicknessDate),
                    response.service_statuses.Single(s => s.GetType() == typeof(AddSicknessRequestHandlerStatuses.InvalidSicknessDate)).GetType()
                    );
        }

        [TestMethod]
        public void check_for_sickness_created_event()
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
            fixture.get_sickness_created_event(fixture.request).Match
                (has_value:
                    e =>
                    {
                        e.sickness_date.Year.Equals((Convert.ToInt32(fixture.request.sickness_date.year)));
                        e.sickness_date.Month.Equals((Convert.ToInt32(fixture.request.sickness_date.month)));
                        e.sickness_date.Day.Equals((Convert.ToInt32(fixture.request.sickness_date.day)));

                    },

                    nothing:
                        () => Assert.Fail("A SicknessEvent was not published."));

        }

        public void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeSicknessRequestHandlerFixture>();
        }

        private AddEmployeeSicknessRequestHandlerFixture fixture;
        public AddSicknessResponse response { get; private set; }
    }
}

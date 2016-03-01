using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.removeHoliday;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.removeHoliday
{
    [TestClass]
    public class remove_holiday_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void check_for_holiday_removed_event()
        {
            // Arrange
            test_setup();

            fixture.request = fixture
                .request_builder
                .set_employee_id(4)
                .set_date(DateTime.Now)
                .build_request()
                ;

            // Act
            response = fixture.execute_command();
            fixture.check_for_holiday_removed_event(fixture.request).Match
                (has_value:
                    e =>
                    {
                        e.holiday_date.Year.Equals((Convert.ToInt32(fixture.request.holiday_date.Date.Year)));
                        e.holiday_date.Month.Equals((Convert.ToInt32(fixture.request.holiday_date.Date.Month)));
                        e.holiday_date.Day.Equals((Convert.ToInt32(fixture.request.holiday_date.Date.Day)));

                    },

                    nothing:
                        () => Assert.Fail("A Remove HolidayEvent was not published."));

        }

        public void test_setup()
        {
            fixture = DependencyResolver.resolve<RemoveHolidayHandlerFixture>();
        }

        private RemoveHolidayHandlerFixture fixture;
        public RemoveHolidayResponse response { get; private set; }
    }
}
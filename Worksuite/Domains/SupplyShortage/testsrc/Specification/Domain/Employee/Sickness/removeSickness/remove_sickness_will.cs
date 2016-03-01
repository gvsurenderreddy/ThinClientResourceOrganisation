using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.removeSickness
{
    [TestClass]
    public class remove_sickness_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void check_for_sickness_removed_event()
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
            fixture.check_for_sickness_removed_event(fixture.request).Match
                (has_value:
                    e =>
                    {
                        e.sickness_date.Year.Equals((Convert.ToInt32(fixture.request.sickness_date.Date.Year)));
                        e.sickness_date.Month.Equals((Convert.ToInt32(fixture.request.sickness_date.Date.Month)));
                        e.sickness_date.Day.Equals((Convert.ToInt32(fixture.request.sickness_date.Date.Day)));

                    },

                    nothing:
                        () => Assert.Fail("A Remove SicknessEvent was not published."));

        }

        public void test_setup()
        {
            fixture = DependencyResolver.resolve<RemoveSicknessHandlerFixture>();
        }

        private RemoveSicknessHandlerFixture fixture;
        public RemoveSicknessResponse response { get; private set; }
    }
}

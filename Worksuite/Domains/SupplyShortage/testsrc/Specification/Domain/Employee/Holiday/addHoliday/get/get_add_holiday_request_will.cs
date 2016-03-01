using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Holiday.addHoliday.get
{
    [TestClass]
    public class get_add_holiday_request_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void return_valid_request( )
        {
            // Arrange
            test_setup( );

            // Act
            response = fixture.execute_command( );

            // Assert
            Assert.AreEqual( fixture.request.employee_id, response.result.employee_id );
        }

        public void test_setup( )
        {
            fixture = DependencyResolver.resolve<GetAddEmployeeHolidayRequestHandlerFixture>( );
        }

        private GetAddEmployeeHolidayRequestHandlerFixture fixture;
        public GetAddHolidayResponse response { get; private set; }
    }
}

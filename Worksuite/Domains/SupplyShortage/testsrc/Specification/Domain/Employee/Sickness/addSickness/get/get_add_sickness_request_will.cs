using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.get;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.Sickness.addSickness.get
{
    [TestClass]
    public class get_add_sickness_request_will : Specification<SupplyShortagesTestBootstrap>
    {
        [TestMethod]
        public void return_valid_request()
        {
            // Arrange
            test_setup();

            // Act
            response = fixture.execute_command();

            // Assert
            Assert.AreEqual(fixture.request.employee_id, response.result.employee_id);
        }

        public void test_setup()
        {
            fixture = new GetAddEmployeeSicknessRequestHandlerFixture();
        }

        private GetAddEmployeeSicknessRequestHandlerFixture fixture;
        public GetAddSicknessResponse response { get; private set; }
    }
}

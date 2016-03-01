using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.get
{
    [TestClass]
    public class get_add_employee_request_handler_will : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void return_the_add_employee_request()
        {
            test_setup();

            //Act
            fixture.execute_command();


            //Assert
            Assert.IsFalse(fixture.response.has_errors());

            Assert.IsNotNull(fixture.response);

            Assert.IsNotNull(fixture.response.result);
        }

        public void test_setup()
        {
            fixture = DependencyResolver.resolve<GetAddEmployeeRequestHandler_fixture>();
        }

        private GetAddEmployeeRequestHandler_fixture fixture;

    }
}

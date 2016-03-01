using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.get.fields.employee_reference
{
    [TestClass]
    public class EmployeeReference_is_returned_empty_to_force_user_entry : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //Arrange
            test_setup();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.result.employee_reference == string.Empty);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<GetAddEmployeeRequestHandler_fixture>();
        }

        private GetAddEmployeeRequestHandler_fixture fixture;
    }
}

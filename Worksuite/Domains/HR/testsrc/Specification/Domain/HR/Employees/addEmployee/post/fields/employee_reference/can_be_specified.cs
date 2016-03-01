using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.employee_reference
{
    [TestClass]
    public class EmployeeReference_can_be_specified : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //Arrange
            test_setup();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.request.employee_reference == fixture.entity.employeeReference);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }

        private AddEmployeeRequestHandler_fixture fixture;
    }
}

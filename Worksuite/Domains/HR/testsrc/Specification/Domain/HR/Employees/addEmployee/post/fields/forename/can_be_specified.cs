using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.forename
{
    [TestClass]
    public class EmployeeForename_can_be_specified : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //Arrange
            test_setup();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.request.forename == fixture.entity.forename);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }

        private AddEmployeeRequestHandler_fixture fixture;
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.title
{
    [TestClass]
    public class EmployeeTitle_defaults_to_not_specified : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //arrange
            test_setup();
            //act
            fixture.execute_command();

            //assert
            Assert.IsTrue(fixture.entity.title == null);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }

        private AddEmployeeRequestHandler_fixture fixture;
    }
}

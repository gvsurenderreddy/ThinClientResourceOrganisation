using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.title
{
    [TestClass]
    public class EmployeeReference_is_unique : Specification<HRTestBootstrap>
    {

        [TestMethod]
        public void verify()
        {
            test_setup();

            //Arrange
            fixture.seed_an_employee_with_this_employee_reference(fixture.request.employee_reference);

            //Act
            fixture.execute_command();


            //Assert
            Assert.IsTrue(fixture.response.has_errors());
            Assert.IsTrue(fixture.response.has_status<AddEmployeeServiceStatuses.EmployeeReferenceIsNotUnique>());
        }


        public void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }

        private AddEmployeeRequestHandler_fixture fixture;
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.image_id
{
    public class EmployeeImageId_defaults_to_null_id : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //arrange
            test_setup();

            //act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.entity.image_id == Null.Id);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }
        private AddEmployeeRequestHandler_fixture fixture;
    }
}

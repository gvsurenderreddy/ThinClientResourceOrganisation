﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.addEmployee.post.fields.gender
{
    public class EmployeeGender_defaults_to_not_specified : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //arrange
            test_setup();

            //act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.entity.gender == null);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<AddEmployeeRequestHandler_fixture>();
        }
        private AddEmployeeRequestHandler_fixture fixture;
    }
}

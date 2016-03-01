using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New
{
    [TestClass]
    public class The_default_fields_are_not_supplied : HRSpecification
    {
        private EmployeeHelper helper;

        [TestMethod]
        public void fields_defaults_to_empty()
        {
            var command = DependencyResolver.resolve<IGetNewAddressRequest>();
            var employee = helper.add().entity;
            var request = command.execute(new EmployeeIdentity { employee_id = employee.id });

            request.number_or_name.Should().BeEmpty();
            request.line_one.Should().BeEmpty();
            request.line_two.Should().BeEmpty();
            request.line_three.Should().BeEmpty();
            request.county.Should().BeEmpty();
            request.postcode.Should().BeEmpty();
        }

        protected override void test_setup()
        {
            helper = DependencyResolver.resolve<EmployeeHelper>();
        }
    }
}
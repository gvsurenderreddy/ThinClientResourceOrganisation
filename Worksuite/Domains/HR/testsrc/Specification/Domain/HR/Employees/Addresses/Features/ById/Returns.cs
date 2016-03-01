using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetById;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.ById
{
    [TestClass]
    public class Returns : HRSpecification
    {
        [TestMethod]
        public void the_address()
        {
            var address = builder.number_or_name("A description").postcode("M33");
            var employee = emp_helper
                           .add().address(address.entity)
                           .entity;

            var response = query.execute(new AddressIdentity { address_id = address.entity.id ,employee_id = employee.id});

            address.entity.id.Should().Be(response.result.address_id);
        }



        protected override void test_setup()
        {
            // (WPM)  Address has been altered

            base.test_setup();
            query = DependencyResolver.resolve<IGetAddressById>();
            builder = new AddressBuilder(new Address());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

        }

        private IGetAddressById query;
        private AddressBuilder builder;
        private EmployeeHelper emp_helper;
    }
}
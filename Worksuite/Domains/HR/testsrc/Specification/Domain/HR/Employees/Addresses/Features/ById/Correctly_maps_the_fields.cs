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
    public class Correctly_maps_the_fields : HRSpecification
    {
        [TestMethod]
        public void address_fields_are_mapped()
        {
             var address = builder.number_or_name("A description").postcode("M33");
             var employee = emp_helper
                            .add().address(address.entity)
                            .entity;

            var response = query.execute(new AddressIdentity {employee_id = employee.id,address_id = address.entity.id});

            Assert.IsTrue(response.result.number_or_Name == builder.entity.number_or_name);
            Assert.IsTrue(response.result.postcode == builder.entity.postcode);
           

        }



        protected override void test_setup()
        {
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
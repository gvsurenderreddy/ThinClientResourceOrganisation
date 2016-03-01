using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetById;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses
{
    [TestClass]
    public class Address_has_a_unique_house_number_and_postcode : HRSpecification
    {
        private EmployeeHelper helper;

        [TestMethod]
        public void postcode_and_housenumber_togather_should_be_unique()
        {
            var command = DependencyResolver.resolve<INewAddress>();
            var employee = helper.add().entity;
            command.execute(new NewAddressRequest
                {
                    number_or_name = "12",
                    line_one = "",
                    line_two = "",
                    postcode = "M23",
                    employee_id = employee.id
                });

            var responce_new =  command.execute(new NewAddressRequest
                {
                    number_or_name = "12",
                    line_three = "",
                    county = "",
                    postcode = "m23",
                    employee_id = employee.id
                });

            Assert.IsTrue(responce_new.has_errors);

        }

        [TestMethod]
        public void postcode_should_have_no_space_at_both_ends()
        {
            var command = DependencyResolver.resolve<INewAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();
            var employee = helper.add().entity;

            var request = new NewAddressRequest
                {
                    number_or_name = "12",
                    line_one = "",
                    line_three = "",
                    county = "",
                    postcode = " m23 ",
                    employee_id = employee.id,
                };

            var responce = command.execute(request);

            var address = query.execute(new AddressIdentity
            {
                address_id = responce.result.address_id,
                employee_id = responce.result.employee_id
            });

            Assert.IsTrue(string.Compare(request.postcode.Trim(), address.result.postcode, true) == 0);

        }

        protected override void test_setup()
        {
            helper = DependencyResolver.resolve<EmployeeHelper>();
        }

    }
}
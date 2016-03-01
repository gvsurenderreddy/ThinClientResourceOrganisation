using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetById;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Addresses;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update
{
    [TestClass]
    public class Update_will : HRSpecification
    {
        [TestMethod]
        public void update_was_called()
        {
            var req = new UpdateAddressRequest
            {
                number_or_name = address.number_or_name,
                line_one = address.line_one,
                line_two = address.line_two,
                line_three = address.line_three,
                county = address.county,
                country = address.country,
                postcode = address.postcode,
                address_id = address.id,
                employee_id = employee.id,
            };

            var response = command.execute(req);
        }

        [TestMethod]
        public void update_without_any_errors()
        {
            var req = new UpdateAddressRequest
            {
                number_or_name = address.number_or_name,
                line_one = address.line_one,
                line_two = address.line_two,
                line_three = address.line_three,
                county = address.county,
                country = address.country,
                postcode = address.postcode,
                address_id = address.id,
                employee_id = employee.id,
            };

            var response = command.execute(req);
            Assert.IsFalse(response.has_errors);
        }

        [TestMethod]
        public void postcode_and_housenumber_togather_should_be_unique()
        {
            var update = DependencyResolver.resolve<IUpdateAddress>();
            var command = DependencyResolver.resolve<INewAddress>();

            var responce_old = command.execute(new NewAddressRequest
            {
                number_or_name = "12",
                line_one = "",
                line_two = "",
                postcode = "M23",
                employee_id = employee.id
            });

            var responce_update = update.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_three = "",
                county = "",
                country = "",
                postcode = "m33",
                address_id = responce_old.result.address_id,
                employee_id = employee.id,
            });

            Assert.IsTrue(responce_update.has_errors);
        }

        [TestMethod]
        public void post_code_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_three = "",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("M33", address_updated.result.postcode);
        }

        [TestMethod]
        public void line1_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_one = "       test    ",
                line_three = "",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("test", address_updated.result.line1);
        }

        [TestMethod]
        public void line1_does_not_have_white_space()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_one = "           ",
                line_three = "",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual(null, address_updated.result.line1);
        }

        [TestMethod]
        public void line2_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "       test    ",
                line_three = "",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("test", address_updated.result.line2);
        }

        [TestMethod]
        public void line2_does_not_have_white_space()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "           ",
                line_three = "",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual(null, address_updated.result.line2);
        }

        [TestMethod]
        public void line3_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_three = "       test    ",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("test", address_updated.result.line3);
        }

        [TestMethod]
        public void line3_does_not_have_white_space()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_three = "             ",
                county = "",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual(null, address_updated.result.line3);
        }

        [TestMethod]
        public void county_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "       test    ",
                line_three = "",
                county = "    test          ",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("test", address_updated.result.county);
        }

        [TestMethod]
        public void county_does_not_have_white_space()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "           ",
                line_three = "",
                county = "                          t",
                country = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("t", address_updated.result.county);
        }

        [TestMethod]
        public void country_does_not_have_white_space_at_start_and_end_of_it()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "       test    ",
                line_three = "",
                country = "    test          ",
                county = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("test", address_updated.result.country);
        }

        [TestMethod]
        public void country_does_not_have_white_space()
        {
            var command = DependencyResolver.resolve<IUpdateAddress>();
            var query = DependencyResolver.resolve<IGetAddressById>();

            var response = command.execute(new UpdateAddressRequest
            {
                number_or_name = "A description",
                line_two = "           ",
                line_three = "",
                country = "                          t",
                county = "",
                postcode = " M33 ",
                address_id = address.id,
                employee_id = employee.id,
            });

            var address_updated = query.execute(new AddressIdentity
            {
                address_id = response.result.address_id,
                employee_id = response.result.employee_id
            });

            Assert.AreEqual("t", address_updated.result.country);
        }

        private void setup_employee_address()
        {
            address = builder.number_or_name("A description").postcode("M33").entity;
            employee = emp_helper
                           .add().address(address)
                           .entity;
        }

        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAddressById>();
            command = DependencyResolver.resolve<IUpdateAddress>();
            builder = new AddressBuilder(new Address());
            emp_helper = DependencyResolver.resolve<EmployeeHelper>();

            setup_employee_address();
        }

        private IGetAddressById query;

        private IUpdateAddress command;

        private AddressBuilder builder;
        private EmployeeHelper emp_helper;

        private Employee employee;
        private Address address;
    }

    [TestClass]
    public class Update_employee_address_details
                        : HRResponseCommandSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture>
    {
        [TestMethod]
        public void should_raise_an_employee_address_details_updated_event()
        {
            fixture.execute_command();

            fixture
                .get_last_address_details_updated_event_for(fixture.entity)
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created

                );
        }
    }
}
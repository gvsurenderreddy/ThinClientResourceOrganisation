using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New
{
    public class NewAddress_will
    {
        [TestClass]
        public class Given_an_employee_when_an_address_is_added_then_it_should_be_in_the_employee_addresses
            : CommandCommitedChangesSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> { }

        [TestClass]
        public class GivenAnEmployeeHasAddressesWorkSuite
                        : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void when_an_address_is_added_to_the_employee_addresses_then_it_should_set_to_highest_priority()
            {
                // Act
                var response = add_address_command.execute(
                    new NewAddressRequest
                    {
                        employee_id = employee.id,
                        number_or_name = "208 Middleton Road",
                        postcode = "M8 4NA"
                    });

                var address_seven = employee.Address.SingleOrDefault(a => a.id == response.result.address_id);

                // Assert
                address_seven.priority.Should().Be(1);
                address_one.priority.Should().Be(2);
                address_two.priority.Should().Be(3);
                address_three.priority.Should().Be(4);
                address_four.priority.Should().Be(5);
                address_five.priority.Should().Be(6);
                address_six.priority.Should().Be(7);
            }

            protected override void test_setup()
            {
                base.test_setup();

                add_address_command = DependencyResolver.resolve<INewAddress>();
            }

            protected INewAddress add_address_command;
        }

        [TestClass]
        public class Create_employee_address_details
                            : HRResponseCommandSpecification<NewAddressRequest,
                                                            NewAddressResponse,
                                                            NewAddressFixture
                                                            >
        {
            [TestMethod]
            public void should_raise_an_employee_address_details_created_event()
            {
                fixture.execute_command();

                fixture
                    .get_last_address_details_created_event_for(fixture.entity)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created.

                        nothing:
                            Assert.Fail // event was not created.

                    );
            }
        }
    }
}
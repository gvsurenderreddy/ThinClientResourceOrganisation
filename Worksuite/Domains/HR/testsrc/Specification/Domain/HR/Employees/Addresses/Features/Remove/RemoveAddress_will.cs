using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Remove
{
    public class RemoveAddress_will
    {
        [TestClass]
        public class GivenAnEmployeeHasAddressesWorkSuite
                            : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void when_an_address_is_deleted_then_it_should_not_be_in_the_employee_addresses()
            {
                // Act
                var response = remove_address_command.execute(
                    new AddressIdentity
                    {
                        employee_id = employee.id,
                        address_id = address_three.id
                    });

                // Assert
                Assert.IsFalse(response.has_errors);
                employee.Address.Should().NotContain(address_three);
            }

            [TestMethod]
            public void when_a_highest_priority_address_is_deleted_then_should_reorder_rest_of_the_addresses()
            {
                // Act
                var response = remove_address_command.execute(
                    new AddressIdentity
                    {
                        employee_id = employee.id,
                        address_id = address_one.id
                    });

                // Assert
                Assert.IsFalse(response.has_errors);
                address_two.priority.Should().Be(1);
                address_three.priority.Should().Be(2);
                address_four.priority.Should().Be(3);
                address_five.priority.Should().Be(4);
                address_six.priority.Should().Be(5);
            }

            [TestMethod]
            public void when_an_address_is_deleted_from_somewhere_in_middle_of_the_order_then_should_reorder_all_the_addresses_below_deleted_address()
            {
                // Act
                var response = remove_address_command.execute(
                    new AddressIdentity
                    {
                        employee_id = employee.id,
                        address_id = address_three.id
                    });

                // Assert
                Assert.IsFalse(response.has_errors);
                address_one.priority.Should().Be(1);
                address_two.priority.Should().Be(2);
                address_four.priority.Should().Be(3);
                address_five.priority.Should().Be(4);
                address_six.priority.Should().Be(5);
            }

            protected override void test_setup()
            {
                base.test_setup();

                remove_address_command = DependencyResolver.resolve<IRemoveAddress>();
            }

            protected IRemoveAddress remove_address_command;
        }

        [TestClass]
        public class Remove_employee_address
                        : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void should_raise_an_employee_address_removed_event()
            {
                _remove_address
                        .execute(new AddressIdentity
                                        {
                                            employee_id = employee.id,
                                            address_id = address_four.id
                                        }
                                )
                        ;

                this
                    .get_last_employee_address_removed_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            private Maybe<EmployeeAddressRemovedEvent> get_last_employee_address_removed_event_for(Employee the_employee)
            {
                var removed_address_event = _event_publisher
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return removed_address_event != null
                            ? new Just<EmployeeAddressRemovedEvent>(removed_address_event) as Maybe<EmployeeAddressRemovedEvent>
                            : new Nothing<EmployeeAddressRemovedEvent>()
                            ;
            }

            protected override void test_setup()
            {
                base.test_setup();

                _remove_address = DependencyResolver.resolve<IRemoveAddress>();
                _event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeAddressRemovedEvent>>();
            }

            private IRemoveAddress _remove_address;
            private FakeEventPublisher<EmployeeAddressRemovedEvent> _event_publisher;
        }
    }
}
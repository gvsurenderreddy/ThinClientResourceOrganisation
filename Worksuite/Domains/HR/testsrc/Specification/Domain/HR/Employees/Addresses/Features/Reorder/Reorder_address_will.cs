using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Remove;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Reorder
{
    public class Reorder_address_will
    {
        // move to a lower order
        //  move the element
        //  change the priority of the elements that have moved
        //  not change the priority of the elements that were not moved

        // move to a higher order
        //  move the element
        //  change the priority of the elements that have moved
        //  not change the priority of the elements that were not moved

        // move to the same position

        [TestClass]
        public class WhenMovingAnAddressWorkSuiteToALowerOrderPosition
                        : ReorderAddressWorkSuiteSpecification
        {
            //  move the element to a lower order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_address_will_be_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_two.id,
                    priority = 5,
                });

                // assert
                address_two.priority.Should().Be(5);
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_two.id,
                    priority = 5,
                });

                // assert
                address_three.priority.Should().Be(2);
                address_four.priority.Should().Be(3);
                address_five.priority.Should().Be(4);
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_two.id,
                    priority = 5,
                });

                address_one.priority.Should().Be(1);
                address_six.priority.Should().Be(6);
            }
        }

        [TestClass]
        public class WhenMovingAnAddressWorkSuiteToAHigherOrderPosition
                        : ReorderAddressWorkSuiteSpecification
        {
            //  move the element to a higher order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_address_will_be_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 2,
                });

                // assert
                address_five.priority.Should().Be(2);
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 2,
                });

                // assert
                address_two.priority.Should().Be(3);
                address_three.priority.Should().Be(4);
                address_four.priority.Should().Be(5);
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 2,
                });

                address_one.priority.Should().Be(1);
                address_six.priority.Should().Be(6);
            }
        }

        [TestClass]
        public class WhenMovingAnAddressWorkSuiteToTheSamePosition
                        : ReorderAddressWorkSuiteSpecification
        {
            //  move the element to the same position
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void all_priorities_remain_as_they_were()
            {
                // act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 5,
                });

                // assert
                address_one.priority.Should().Be(1);
                address_two.priority.Should().Be(2);
                address_three.priority.Should().Be(3);
                address_four.priority.Should().Be(4);
                address_five.priority.Should().Be(5);
                address_six.priority.Should().Be(6);
            }
        }

        [TestClass]
        public class WhenAnAddressIsCreated
                        : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_address_reordered_events()
            {
                // Act
                var response = _new_address_command.execute(
                    new NewAddressRequest
                    {
                        employee_id = employee.id,
                        number_or_name = "208 Middleton Road",
                        postcode = "M8 4NA"
                    });

                this
                    .get_last_employee_address_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            private Maybe<EmployeeAddressAutoReorderedEvent> get_last_employee_address_reordered_event_for(Employee the_employee)
            {
                var reordered_address_event = _event_publisher
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_address_event != null
                            ? new Just<EmployeeAddressAutoReorderedEvent>(reordered_address_event) as Maybe<EmployeeAddressAutoReorderedEvent>
                            : new Nothing<EmployeeAddressAutoReorderedEvent>()
                            ;
            }

            protected override void test_setup()
            {
                base.test_setup();

                _new_address_command = DependencyResolver.resolve<INewAddress>();
                _event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeAddressAutoReorderedEvent>>();
            }

            protected INewAddress _new_address_command;
            private FakeEventPublisher<EmployeeAddressAutoReorderedEvent> _event_publisher;
        }

        [TestClass]
        public class WhenAnAddressIsRemoved
                        : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_address_reordered_events()
            {
                // Act
                var response = _remove_address_command.execute(
                    new AddressIdentity
                    {
                        employee_id = employee.id,
                        address_id = address_three.id
                    });

                this
                    .get_last_employee_address_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            private Maybe<EmployeeAddressAutoReorderedEvent> get_last_employee_address_reordered_event_for(Employee the_employee)
            {
                var reordered_address_event = _event_publisher
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_address_event != null
                            ? new Just<EmployeeAddressAutoReorderedEvent>(reordered_address_event) as Maybe<EmployeeAddressAutoReorderedEvent>
                            : new Nothing<EmployeeAddressAutoReorderedEvent>()
                            ;
            }

            protected override void test_setup()
            {
                base.test_setup();

                _remove_address_command = DependencyResolver.resolve<IRemoveAddress>();
                _event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeAddressAutoReorderedEvent>>();
            }

            protected IRemoveAddress _remove_address_command;
            private FakeEventPublisher<EmployeeAddressAutoReorderedEvent> _event_publisher;
        }

        [TestClass]
        public class WhenAnAddressIsReordered
                        : ReorderAddressWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_an_employee_address_manual_reordered_event()
            {
                // Act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 2,
                });

                this
                    .get_last_employee_address_manual_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            [TestMethod]
            public void that_should_raise_employee_address__reordered_events()
            {
                // Act
                reorder_address.execute(new ReorderAddressRequest
                {
                    employee_id = employee.id,
                    address_id = address_five.id,
                    priority = 2,
                });

                this
                    .get_last_employee_address_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            private Maybe<EmployeeAddressManualReorderedEvent> get_last_employee_address_manual_reordered_event_for(Employee the_employee)
            {
                var reordered_address_event = _event_publisher_manual_reordered_event
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_address_event != null
                            ? new Just<EmployeeAddressManualReorderedEvent>(reordered_address_event) as Maybe<EmployeeAddressManualReorderedEvent>
                            : new Nothing<EmployeeAddressManualReorderedEvent>()
                            ;
            }

            private Maybe<EmployeeAddressAutoReorderedEvent> get_last_employee_address_reordered_event_for(Employee the_employee)
            {
                var reordered_address_event = _event_publisher_reordered_event
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_address_event != null
                            ? new Just<EmployeeAddressAutoReorderedEvent>(reordered_address_event) as Maybe<EmployeeAddressAutoReorderedEvent>
                            : new Nothing<EmployeeAddressAutoReorderedEvent>()
                            ;
            }

            protected override void test_setup()
            {
                base.test_setup();

                _remove_address_command = DependencyResolver.resolve<IRemoveAddress>();
                _event_publisher_manual_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeAddressManualReorderedEvent>>();
                _event_publisher_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeAddressAutoReorderedEvent>>();
            }

            protected IRemoveAddress _remove_address_command;
            private FakeEventPublisher<EmployeeAddressManualReorderedEvent> _event_publisher_manual_reordered_event;
            private FakeEventPublisher<EmployeeAddressAutoReorderedEvent> _event_publisher_reordered_event;
        }
    }
}
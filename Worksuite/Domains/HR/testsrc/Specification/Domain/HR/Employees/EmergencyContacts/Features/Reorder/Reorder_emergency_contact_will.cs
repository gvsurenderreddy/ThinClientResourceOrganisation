using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Remove;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Reorder
{
    public class Reorder_emergency_contact_will
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
        public class WhenMovingAnEmergencyContactWorkSuiteToALowerOrderPosition
                            : ReorderEmergencyContactWorkSuiteSpecification
        {
            //  move the element to a lower order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_emergency_contact_will_be_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                emergency_contact_two.priority.Should().Be( 5 );
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                emergency_contact_three.priority.Should().Be( 2 );
                emergency_contact_four.priority.Should().Be( 3 );
                emergency_contact_five.priority.Should().Be( 4 );
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                emergency_contact_one.priority.Should().Be( 1 );
                emergency_contact_six.priority.Should().Be( 6 );
            }

        }

        [TestClass]
        public class WhenMovingAnEmergencyContactWorkSuiteToAHigherOrderPosition
                            : ReorderEmergencyContactWorkSuiteSpecification
        {
            //  move the element to a higher order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_emergency_contact_will_be_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                        {
                                                            employee_id = employee.id,
                                                            emergency_contact_id = emergency_contact_five.id,
                                                            priority = 2
                                                        }
                                                  );

                // Assert
                emergency_contact_five.priority.Should().Be( 2 );
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_five.id,
                                                        priority = 2
                                                    }
                                                  );
                // Assert
                emergency_contact_two.priority.Should().Be( 3 );
                emergency_contact_three.priority.Should().Be( 4 );
                emergency_contact_four.priority.Should().Be( 5 );
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_five.id,
                                                        priority = 2
                                                    }
                                                  );
                // Assert
                emergency_contact_one.priority.Should().Be( 1 );
                emergency_contact_six.priority.Should().Be( 6 );
            }
            
        }

        [TestClass]
        public class WhenMovingAnEmergencyContactWorkSuiteToTheSamePosition
                            : ReorderEmergencyContactWorkSuiteSpecification
        {
            //  move the element to the same position
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void all_priorities_remain_as_they_were()
            {
                // Act
                reorder_emergency_contact.execute( new ReorderEmergencyContactRequest
                                                    {
                                                        employee_id = employee.id,
                                                        emergency_contact_id = emergency_contact_four.id,
                                                        priority = 4
                                                    }
                                                 );

                // Assert
                emergency_contact_one.priority.Should().Be( 1 );
                emergency_contact_two.priority.Should().Be( 2 );
                emergency_contact_three.priority.Should().Be( 3 );
                emergency_contact_four.priority.Should().Be( 4 );
                emergency_contact_five.priority.Should().Be( 5 );
                emergency_contact_six.priority.Should().Be( 6 );
            }
        }


        [TestClass]
        public class WhenAnEmergencyContactIscreated
                           : ReorderEmergencyContactWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_emergency_contact_reordered_events()
            {
                // Act
                var response = new_emergency_contact_command.execute(
                    new NewEmergencyContactRequest()
                    {
                        employee_id = employee.id,
                        name = "Fatemeh",
                        primary_phone_number = "07922222222",
                        other_phone_number = "0789456123",
                    });

                this
                    .get_last_employee_emergency_contact_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }

            private Maybe<EmployeeEmergencyContactAutoReorderedEvent> get_last_employee_emergency_contact_reordered_event_for(Employee the_employee)
            {
                var reordered_emergency_contact_event = event_publisher
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_emergency_contact_event != null
                            ? new Just<EmployeeEmergencyContactAutoReorderedEvent>(reordered_emergency_contact_event) as Maybe<EmployeeEmergencyContactAutoReorderedEvent>
                            : new Nothing<EmployeeEmergencyContactAutoReorderedEvent>()
                            ;
            }
            
            
            protected override void test_setup()
            {
                base.test_setup();

                new_emergency_contact_command = DependencyResolver.resolve<INewEmergencyContact>();
                event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent>>();
            }

            protected INewEmergencyContact new_emergency_contact_command;
            private FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher;
        }

        [TestClass]
        public class WhenAnEmergencyContactIsRemoved
                          : ReorderEmergencyContactWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_employee_emergency_contact_reordered_events()
            {
                // Act
                var response = remove_emergency_contact_command.execute(
                    new EmergencyContactIdentity()
                    {
                       employee_id = employee.id,
                       emergency_contact_id = emergency_contact_three.id
                    });

                this
                    .get_last_employee_emeregency_contact_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }


            private Maybe<EmployeeEmergencyContactAutoReorderedEvent> get_last_employee_emeregency_contact_reordered_event_for(Employee the_employee)
            {
                var reordered_emergency_contact_event = event_publisher
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_emergency_contact_event != null
                            ? new Just<EmployeeEmergencyContactAutoReorderedEvent>(reordered_emergency_contact_event) as Maybe<EmployeeEmergencyContactAutoReorderedEvent>
                            : new Nothing<EmployeeEmergencyContactAutoReorderedEvent>()
                            ;
            }

            protected override void test_setup()
            {
                base.test_setup();

                remove_emergency_contact_command = DependencyResolver.resolve<IRemoveEmergencyContact>();
                event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent>>();
            }

            protected IRemoveEmergencyContact remove_emergency_contact_command;
            private FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher;
        }

        [TestClass]
        public class WhenAnEmergencyContactIsReordered
                           : ReorderEmergencyContactWorkSuiteSpecification
        {
            [TestMethod]
            public void that_should_raise_an_employee_emergency_contact_manual_reordered_event()
            {
                reorder_emergency_contact.execute(new ReorderEmergencyContactRequest()
                {
                    employee_id = employee.id,
                    emergency_contact_id = emergency_contact_five.id,
                    priority = 2,

                });

                this
                    .get_last_employee_emergency_contact_manual_reordered_event_for(employee)
                    .Match(
                        has_value:
                            created_evet => Assert.IsTrue(true),

                        nothing:
                            Assert.Fail
                    );
            }


            private Maybe<EmployeeEmergencyContactManualReorderedEvent> get_last_employee_emergency_contact_manual_reordered_event_for(Employee the_employee)
            {
                var reordered_emergency_contact_event = event_publisher_manual_reordered_event
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_emergency_contact_event != null
                            ? new Just<EmployeeEmergencyContactManualReorderedEvent>(reordered_emergency_contact_event) as Maybe<EmployeeEmergencyContactManualReorderedEvent>
                            : new Nothing<EmployeeEmergencyContactManualReorderedEvent>()
                            ;
            }

            [TestMethod]
            public void that_shoudl_raise_employee_emergency_contact_reordered_events()
            {
                reorder_emergency_contact.execute(new ReorderEmergencyContactRequest()
                {
                    employee_id = employee.id,
                    emergency_contact_id = emergency_contact_five.id,
                    priority = 2,

                });

                this
                    .get_last_employee_emergency_contact_Auto_reordered_event_for(employee)
                    .Match(

                        has_value:
                            created_event => Assert.IsTrue(true), // event was created

                        nothing:
                            Assert.Fail // event was not created
                    );
            }



            private Maybe<EmployeeEmergencyContactAutoReorderedEvent> get_last_employee_emergency_contact_Auto_reordered_event_for(Employee the_employee)
            {
                var reordered_emergency_contact_event = event_publisher_auto_reordered_event
                                                .published_events
                                                .LastOrDefault(e => e.employee_id == the_employee.id)
                                                ;

                return reordered_emergency_contact_event != null
                            ? new Just<EmployeeEmergencyContactAutoReorderedEvent>(reordered_emergency_contact_event) as Maybe<EmployeeEmergencyContactAutoReorderedEvent>
                            : new Nothing<EmployeeEmergencyContactAutoReorderedEvent>()
                            ;
            }


            protected override void test_setup()
            {
                base.test_setup();

                remove_emergency_contact_command = DependencyResolver.resolve<IRemoveEmergencyContact>();
                event_publisher_manual_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeEmergencyContactManualReorderedEvent>>();
                event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent>>();
            }

            protected IRemoveEmergencyContact remove_emergency_contact_command;
            private FakeEventPublisher<EmployeeEmergencyContactManualReorderedEvent> event_publisher_manual_reordered_event;
            private FakeEventPublisher<EmployeeEmergencyContactAutoReorderedEvent> event_publisher_auto_reordered_event;
        }
    }
}
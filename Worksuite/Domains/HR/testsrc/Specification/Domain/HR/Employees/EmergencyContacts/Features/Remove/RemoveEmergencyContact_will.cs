using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Remove
{

    public class RemoveEmergencyContact_will
    {
        [TestClass]
        public class GivenAnEmployeeHasEmergencyContactsWorkSuite
                                : ReorderEmergencyContactWorkSuiteSpecification
        {
            [TestMethod]
            public void when_an_emergency_contact_is_deleted_then_it_should_not_be_in_the_employee_emergency_contacts()
            {
                // Act
                var response = remove_emergency_contact_command.execute( new EmergencyContactIdentity
                                                                            {
                                                                                employee_id = employee.id,
                                                                                emergency_contact_id = emergency_contact_two.id
                                                                            }
                                                                       );

                // Assert
                Assert.IsFalse(response.has_errors);
                employee.EmergencyContacts.Should().NotContain( emergency_contact_two );
            }

            [TestMethod]
            public void when_a_highest_priority_emergency_contact_is_deleted_then_should_reorder_rest_of_the_emergency_contacts()
            {
                // Act
                var response = remove_emergency_contact_command.execute( new EmergencyContactIdentity
                                                                            {
                                                                                employee_id = employee.id,
                                                                                emergency_contact_id = emergency_contact_one.id
                                                                            }
                                                                       );

                // Assert
                Assert.IsFalse(response.has_errors);
                emergency_contact_two.priority.Should().Be(1);
                emergency_contact_three.priority.Should().Be(2);
                emergency_contact_four.priority.Should().Be(3);
                emergency_contact_five.priority.Should().Be(4);
                emergency_contact_six.priority.Should().Be(5);
            }

            [TestMethod]
            public void
                when_an_emergency_contact_is_deleted_from_somewhere_in_middle_of_the_order_then_should_reorder_all_the_emergency_contacts_below_deleted_emergency_contact()
            {
                // Act
                var response = remove_emergency_contact_command.execute( new EmergencyContactIdentity
                                                                            {
                                                                                employee_id = employee.id,
                                                                                emergency_contact_id = emergency_contact_three.id
                                                                            }
                                                                       );

                // Assert
                Assert.IsFalse(response.has_errors);
                emergency_contact_one.priority.Should().Be( 1 );
                emergency_contact_two.priority.Should().Be( 2 );
                emergency_contact_four.priority.Should().Be( 3 );
                emergency_contact_five.priority.Should().Be( 4 );
                emergency_contact_six.priority.Should().Be( 5 );
            }

            protected override void test_setup()
            {
                base.test_setup();

                remove_emergency_contact_command = DependencyResolver.resolve<IRemoveEmergencyContact>();
            }

            protected IRemoveEmergencyContact remove_emergency_contact_command;

            [TestClass]
            public class Remove_Emergency_Contact
                                     : ReorderEmergencyContactWorkSuiteSpecification
            {
                [TestMethod]
                public void sould_raise_an_emergency_contact_removed_event()
                {

                    remove_emergency_contact
                                    .execute(new EmergencyContactIdentity() 
                                            {  emergency_contact_id = emergency_contact_four.id
                                               , employee_id = employee.id
                                            });

                    this
                        .get_last_employee_emergency_contact_removed_event_for(employee)
                        .Match(
                            has_value:
                                created_event => Assert.IsTrue(true),

                            nothing: 
                            Assert.Fail
                        );
                }

                private Maybe<EmployeeEmergencyContactDetailsRemoveEvent> get_last_employee_emergency_contact_removed_event_for(Employee the_employee)
                {
                    var removed_emergency_contact_event = event_publisher
                                                    .published_events
                                                    .LastOrDefault(e => e.employee_id == the_employee.id)
                                                    ;

                    return removed_emergency_contact_event != null
                                ? new Just<EmployeeEmergencyContactDetailsRemoveEvent>(removed_emergency_contact_event) as Maybe<EmployeeEmergencyContactDetailsRemoveEvent>
                                : new Nothing<EmployeeEmergencyContactDetailsRemoveEvent>()
                                ;
                }

                protected override void test_setup()
                {
                    base.test_setup();

                    remove_emergency_contact = DependencyResolver.resolve<IRemoveEmergencyContact>();
                    event_publisher =DependencyResolver.resolve<FakeEventPublisher<EmployeeEmergencyContactDetailsRemoveEvent>>();
                }
                private IRemoveEmergencyContact remove_emergency_contact;
                private FakeEventPublisher<EmployeeEmergencyContactDetailsRemoveEvent> event_publisher;
            }
            
        }
    }
}
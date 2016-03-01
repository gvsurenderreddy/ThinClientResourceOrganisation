using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New {

    public class NewEmergencyContact_will
    {
        [TestClass]
        public class Given_an_employee_when_an_emergency_contact_is_added_then_it_should_be_in_the_employee_emergency_contacts
            : CommandCommitedChangesSpecification<NewEmergencyContactRequest, NewEmergencyContactResponse, NewEmergencyContactFixture> { }

        [TestClass]
        public class GivenAnEmployeeHasEmergencyContactsWorkSuite
                        : ReorderEmergencyContactWorkSuiteSpecification
        {
            [TestMethod]
            public void when_an_emergency_contact_is_added_to_the_employee_emergency_contacts_then_it_should_set_to_highest_priority()
            {
                // Act
                var response = add_emergency_contact_command.execute(
                    new NewEmergencyContactRequest
                    {
                        employee_id         = employee.id,
                        name                = "Wife",
                        primary_phone_number    = "1234567"
                    });

                var emergency_contact_seven = employee.EmergencyContacts.SingleOrDefault(a => a.id == response.result.emergency_contact_id);

                // Assert
                emergency_contact_seven.priority.Should().Be(1);
                emergency_contact_one.priority.Should().Be(2);
                emergency_contact_two.priority.Should().Be(3);
                emergency_contact_three.priority.Should().Be(4);
                emergency_contact_four.priority.Should().Be(5);
                emergency_contact_five.priority.Should().Be(6);
                emergency_contact_six.priority.Should().Be(7);
            }

            protected override void test_setup()
            {
                base.test_setup();

                add_emergency_contact_command = DependencyResolver.resolve<INewEmergencyContact>();
            }

            protected INewEmergencyContact add_emergency_contact_command;
        }

        [TestClass]
        public class create_emergency_address_command
                                         : HRResponseCommandSpecification< NewEmergencyContactRequest 
                                                                          ,NewEmergencyContactResponse
                                                                          ,NewEmergencyContactFixture>
        {
            [TestMethod]
            public void should_raise_an_emergency_contact_details_create_event()
            {
                fixture.execute_command();
                fixture
                    .get_last_emergency_contact_details_created_event_for(fixture.entity)
                    .Match(
                           has_value:
                               add_eveny => Assert.IsTrue(true),
                         
                           nothing:
                              Assert.Fail
                    );
            }
        }
    }
}
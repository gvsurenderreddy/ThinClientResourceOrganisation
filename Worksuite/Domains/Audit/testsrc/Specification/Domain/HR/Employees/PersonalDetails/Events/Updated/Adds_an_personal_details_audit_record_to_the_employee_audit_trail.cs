using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated
{
    [TestClass]
    public class Adds_an_personal_details_audit_record_to_the_employee_audit_trail
                    : EmployeePersonalDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void an_employee_personal_details_update_audit_record_is_added_to_the_employee_audit_trail()
        {
            var update_event = fixture.create_event();

            fixture.event_handler.handle(update_event);

            fixture
                .get_last_personal_details_audit_record_for(update_event)
                .Match(

                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeePersonalDetailsUpdatedEvent).Name);
                            fixture.clock.is_clock_time(audit_record.received_at);
                        },

                    nothing:
                        () => { Assert.Fail("audit record not created"); }
                );
        }

        [TestMethod]
        public void will_create_an_audit_trail_for_the_employee_if_one_does_not_exist()
        {
            // arrange
            var update_event = fixture.create_event();

            fixture.clear_all_audit_trails();

            // act
            fixture.event_handler.handle(update_event);

            // assert
            fixture
                .get_employee_audit_trail_for(update_event)
                .Match(

                    has_value:
                        audit_trail => { },  // success an audit trail has been created

                    nothing:
                        () => { Assert.Fail("Audit trail not creaed."); }
                );
        }

        [TestMethod]
        public void changes_are_committed()
        {
            var update_event = fixture.create_event();

            fixture.event_handler.handle(update_event);

            fixture.changes_were_committed().Should().BeTrue();
        }
    }
}
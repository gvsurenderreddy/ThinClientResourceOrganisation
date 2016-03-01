using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated
{
    [TestClass]
    public class Adds_an_employment_details_audit_record_to_the_employee_audit_trail
                    : EmployeeEmploymentDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void an_employment_details_updated_audit_record_is_added_to_the_employee_audit_trail()
        {
            var update_event = fixture.create_event();

            fixture.event_handler.handle(update_event);

            fixture
                .get_last_employment_details_audit_record_for(update_event)
                .Match(

                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeeEmploymentDetailsUpdatedEvent).Name);
                            fixture.clock.is_clock_time(audit_record.received_at).Should().BeTrue();
                        },

                    nothing:
                        () => { Assert.Fail("Audit record not found"); }
                );
        }

        [TestMethod]
        public void will_create_an_audit_trail_for_the_employee_if_one_does_not_exist()
        {
            var update_event = fixture.create_event();
            fixture.clear_all_audit_trails();

            fixture.event_handler.handle(update_event);

            fixture
                .get_employee_audit_trail_for(update_event)
                .Match(

                // if we find an audit trail then it must have been created as part of the
                // update event because the audit trail was cleared before the event was handled
                has_value:
                    audit_trail => { },

                nothing:
                    () => { Assert.Fail("Audit trail not found."); }
                );
        }

        [TestMethod]
        public void changes_are_commited()
        {
            var update_event = fixture.create_event();

            fixture.event_handler.handle(update_event);

            fixture.changes_were_committed().Should().BeTrue();
        }
    }
}
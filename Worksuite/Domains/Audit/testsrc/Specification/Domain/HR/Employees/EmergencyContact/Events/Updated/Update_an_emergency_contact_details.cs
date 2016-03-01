using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Updated
{
    [TestClass]
    public class UpdateAnEmployeeEmergencyContactDetails
                        : EmployeeEmergencyContactDetailsUpdateEventSpecification
    {
        [TestMethod]
        public void should_add_an_emergency_contact_details_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();
            var update_event = fixture.create_event();
            fixture.event_handler.handle(update_event);

            fixture.get_employee_audit_trail_for(update_event)
                .Match(
                    has_value:
                        audit_trail =>
                        {
                            audit_trail.emergency_contact_details_audit.Count.Should().Be(1);
                            audit_trail.emergency_contact_details_audit.Should()
                                       .Contain(em => em.triggered_by_event == typeof(EmployeeEmergencyContactDetailsUpdateEvent).Name &&
                                                 fixture.fake_clock.is_clock_time(em.received_at));
                        },

                    nothing:
                     Assert.Fail
                );
        }

        [TestMethod]
        public void should_add_an_emergency_contact_details_updated_audit_record_to_the_employee_audit_trail()
        {
            var update_event = fixture.create_event();
            fixture.event_handler.handle(update_event);

            fixture
                .get_last_emergency_contact_details_audit_record_for(update_event)
                .Match(

                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeeEmergencyContactDetailsUpdateEvent).Name);
                            fixture.fake_clock.is_clock_time(audit_record.received_at);
                        },

                    nothing:
                        () => { Assert.Fail("Audit record not updated"); }

                );
        }

        [TestMethod]
        public void should_commit_changes()
        {
            var update_event = fixture.create_event();
            fixture.event_handler.handle(update_event);
            fixture.changes_shoudl_be_committed().Should().BeTrue();
        }
    }
}
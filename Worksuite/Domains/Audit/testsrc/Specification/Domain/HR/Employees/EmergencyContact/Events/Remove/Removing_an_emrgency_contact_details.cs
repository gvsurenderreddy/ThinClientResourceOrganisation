using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Remove
{
    [TestClass]
    public class Removing_an_emrgency_contact_details
                     : EmployeeEmergencyContactDetailsRemoveEventSpecification
    {
        [TestMethod]
        public void should_add_an_emergency_contact_details_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();

            var remove_event = fixture.create_event();

            fixture.event_handler.handle(remove_event);

            fixture
                .get_employee_audit_trail_for(remove_event)
                .Match(
                has_value:
                    audi_trail =>
                    {
                        audi_trail.emergency_contact_details_audit.Count.Should().Be(1);
                        audi_trail.emergency_contact_details_audit.Should()
                            .Contain(a => a.triggered_by_event == typeof (EmployeeEmergencyContactDetailsRemoveEvent).Name
                                     && fixture.clock.is_clock_time(a.received_at));
                    },

                    nothing: 
                      Assert.Fail

                );
        }

        [TestMethod]
        public void should_add_an_employee_emergency_contact_details_removed_audit_record_to_the_employee_audit_trails()
        {
            var remove_event = fixture.create_event();
            fixture.event_handler.handle(remove_event);
            fixture
                .get_last_emergency_contact_details_audit_record_for(remove_event)
                .Match(
                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeeEmergencyContactDetailsRemoveEvent).Name);
                            fixture.clock.is_clock_time(audit_record.received_at);
                        },
                    nothing:
                        () => { Assert.Fail("Audit record not created"); }

                );
        }

        [TestMethod]
        public void should_commit_changes()
        {
            var remove_event = fixture.create_event();
            fixture.event_handler.handle(remove_event);
            fixture.changes_were_committed().Should().BeTrue();
        }
    }
}
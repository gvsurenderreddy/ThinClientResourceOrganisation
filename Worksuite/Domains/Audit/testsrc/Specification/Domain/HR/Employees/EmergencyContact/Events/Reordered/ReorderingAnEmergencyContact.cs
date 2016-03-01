using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Reordered
{
    [TestClass]
    public class ReorderingAnEmergencyContact
                   : EmployeeEmergencyContactReorderedEventSpecification
    {
        [TestMethod]
        public void should_add_an_emergency_contact_details_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();
            var reorder_event = fixture.create_event();
            fixture.event_handler.handle(reorder_event);

            fixture
                .get_employee_audit_trail_for(reorder_event)
                .Match(
                    has_value:
                        audit_trail =>
                        {
                            audit_trail.emergency_contact_details_audit.Count.Should().Be(1);
                            audit_trail.emergency_contact_details_audit.Should().Contain(
                                e => e.triggered_by_event == typeof (EmployeeEmergencyContactAutoReorderedEvent).Name
                                     && fixture.fake_clock.is_clock_time(e.received_at)
                                );
                        },

                    nothing:
                        Assert.Fail
                );
        }

        [TestMethod]
        public void should_add_an_emergency_contact_reordered_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();
            var reordered_event = fixture.create_event();
            fixture.event_handler.handle(reordered_event);

            fixture
                .get_last_emergency_contact_audit_record_for(reordered_event)
                .Match(
                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should()
                                .Be(typeof (EmployeeEmergencyContactAutoReorderedEvent).Name);
                            fixture.fake_clock.is_clock_time(audit_record.received_at);
                        },

                    nothing:
                        () => { Assert.Fail("Audit record not created."); }

                );
        }

        public void shoudl_commit_changes()
        {
            var reorder_event = fixture.create_event();
            fixture.event_handler.handle(reorder_event);
            fixture.Changes_were_commited().Should().BeTrue();
        }


    }
}
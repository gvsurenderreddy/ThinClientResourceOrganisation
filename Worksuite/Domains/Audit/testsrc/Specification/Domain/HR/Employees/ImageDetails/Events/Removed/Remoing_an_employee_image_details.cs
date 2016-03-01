using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ImageDetails.Events.Removed
{
    [TestClass]
    public class Remoing_an_employee_image_details
                    : EmployeeImageDetailsRemovedEventSpecification
    {
        [TestMethod]
        public void should_add_an_employee_image_details_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();

            var remove_event = fixture.create_event();

            fixture.event_handler.handle(remove_event);

            fixture
                .get_employee_audit_trail_for(remove_event)
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            audit_trail.image_details_audit.Count.Should().Be(1);
                            audit_trail.image_details_audit.Should()
                                .Contain(
                                    id => id.triggered_by_event == typeof(EmployeeImageDetailsRemovedEvent).Name &&
                                          fixture.clock.is_clock_time(id.received_at)
                                );
                        },

                    nothing:
                        Assert.Fail
                );
        }

        [TestMethod]
        public void should_add_an_employee_image_details_updated_audit_record_to_the_employee_audit_trail()
        {
            var remove_event = fixture.create_event();

            fixture.event_handler.handle(remove_event);

            fixture
                .get_last_image_details_audit_record_for(remove_event)
                .Match(

                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeeImageDetailsRemovedEvent).Name);
                            fixture.clock.is_clock_time(audit_record.received_at);
                        },

                    nothing:
                        () => { Assert.Fail("Audit record not found."); }
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
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created
{
    [TestClass]
    public class Adds_an_employee_contact_details_audit_record
                        : EmployeeCreatedEventSpecification
    {
        [TestMethod]
        public void adds_an_employee_contact_details_audit_record_to_the_employee_audit_trail()
        {
            var created_event = fixture.create_event();

            fixture.event_handler.handle(created_event);

            fixture
                .get_employee_audit_trail_for(created_event)
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            audit_trail.contact_details_audit.Count.Should().Be(1);
                            audit_trail.contact_details_audit.Should()
                                .Contain(cd => cd.triggered_by_event == typeof(EmployeeCreatedEvent).Name
                                               && fixture.clock.is_clock_time(cd.received_at));
                        },

                    nothing:
                        Assert.Fail
                );
        }
    }
}
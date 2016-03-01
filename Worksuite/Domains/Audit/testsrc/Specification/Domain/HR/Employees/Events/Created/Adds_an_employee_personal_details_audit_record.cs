using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created
{
    [TestClass]
    public class Adds_an_employee_personal_details_audit_record
                    : EmployeeCreatedEventSpecification
    {
        [TestMethod]
        public void add_employee_personal_details_audit_record_to_the_employee_audit_trail()
        {
            var created_event = fixture.create_event();

            fixture.event_handler.handle(created_event);

            fixture
                .get_employee_audit_trail_for(created_event)
                .Match(

                    has_value: audit_trail =>
                    {
                        audit_trail.personal_details_audit.Count.Should().Be(1);
                        audit_trail.personal_details_audit.Should().Contain(pd => pd.triggered_by_event == typeof(EmployeeCreatedEvent).Name
                                                                                    && fixture.clock.is_clock_time(pd.received_at));
                    },

                    nothing:
                        Assert.Fail // no audit trail

                );
        }
    }
}
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated
{
    [TestClass]
    public class Adds_an_employee_created_audit_record_if_creating_the_audit_trail
                    : EmployeeEmploymentDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void creates_an_employee_created_audit_record_in_the_employees_audit_trail()
        {
            var create_event = fixture.create_event();

            fixture.clear_all_audit_trails();
            fixture.event_handler.handle(create_event);

            fixture
                .get_employee_audit_trail_for(create_event)
                .Match(

                    has_value: audit_trail =>
                    {
                        audit_trail.employee_audit.Should().Contain(ar => ar.triggered_by_event == typeof(EmployeeEmploymentDetailsUpdatedEvent).Name
                                                                        && fixture.clock.is_clock_time(ar.received_at));
                    },

                    nothing:
                        Assert.Fail

                );
        }
    }
}
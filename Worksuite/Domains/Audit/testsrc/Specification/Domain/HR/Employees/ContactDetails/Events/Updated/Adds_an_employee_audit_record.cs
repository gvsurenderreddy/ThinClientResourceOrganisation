using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Events.Updated
{
    [TestClass]
    public class Adds_an_employee_audit_record
                        : EmployeeContactDetailsUpdatedEventSpecification
    {
        [TestMethod]
        public void creates_an_employee_contact_details_updated_audit_record_in_the_employee_audit_trail()
        {
            var create_event = fixture.create_event();

            fixture.event_handler.handle(create_event);

            fixture
                .get_employee_audit_trail_for(create_event)
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            audit_trail.employee_audit.Should()
                                .Contain(ar => ar.triggered_by_event == typeof(EmployeeContactDetailsUpdatedEvent).Name &&
                                          fixture.clock.is_clock_time(ar.received_at)
                                        )
                                ;
                        },

                    nothing:
                        Assert.Fail
                );
        }
    }
}
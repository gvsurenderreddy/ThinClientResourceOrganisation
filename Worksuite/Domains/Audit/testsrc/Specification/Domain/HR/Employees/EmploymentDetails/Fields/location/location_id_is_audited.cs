using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Fields.location
{
    public class location_id_is_audited
    {
        public class in_the_employment_details_audit_record
        {
            [TestClass]
            public class on_employment_details_updated
                            : EmployeeEmploymentDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_employee_location_id_state_change_is_recorded_in_the_emplopyees_audit_trail()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_employment_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.location_id.Should().Be(update_event.location_id),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }

                [TestMethod]
                public void the_employee_location_description_state_change_is_recorded_in_the_emplopyees_audit_trail()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_employment_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.location_description.Should().Be(update_event.location_description),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }
            }
        }
    }
}
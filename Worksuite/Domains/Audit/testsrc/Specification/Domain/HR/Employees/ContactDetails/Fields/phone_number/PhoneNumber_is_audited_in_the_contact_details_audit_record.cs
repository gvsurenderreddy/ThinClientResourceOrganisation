using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Events.Updated;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Fields.phone_number
{
    public class PhoneNumber_is_audited_in_the_contact_details_audit_record
    {
        [TestClass]
        public class On_create_employee
                            : EmployeeCreatedEventSpecification
        {
            [TestMethod]
            public void a_null_phone_number_is_written_to_the_employee_contact_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_contact_details_audit_record_for(create_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.phone_number.Should().BeNull(),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_update_contact_details
                    : EmployeeContactDetailsUpdatedEventSpecification
        {
            [TestMethod]
            public void the_phone_number_is_written_to_the_employee_contact_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_contact_details_audit_record_for(update_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.phone_number.Should().Be(update_event.phone_number),

                        nothing:
                            () => { Assert.Fail("Audit record not found."); }
                    );
            }
        }
    }
}
using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Remove;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Updated;
using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Fields.OtherPhoneNumber
{
    public class OtherPhoneNumber_is_audited_in_the_correct_details_audit_record
                                      : AuditSpecification
    {
        [TestClass]
        public class on_create_an_emergency_contact_other_phone_number
                                      : EmployeeEmergencyContactDetailsCreatedEventSpecification
        {
            [TestMethod]
            public void should_write_other_phone_number_with_the_input_value_to_the_employee_emergency_contact_details_audit_record()
            {
                var create_event = fixture.create_event();
                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_emergency_contact_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.other_phone_number.Should().Be(create_event.other_phone_number),

                        nothing:
                            () => Assert.Fail("")
                    );
            }
        }

        [TestClass]
        public class on_update_an_emergency_contact_other_phone_number
                                    : EmployeeEmergencyContactDetailsUpdateEventSpecification
        {
            [TestMethod]
            public void should_update_emergency_contact_with_the_input_value_to_the_emergency_contact_details_audit_record()
            {
                var update_event = fixture.create_event();
                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_emergency_contact_details_audit_record_for(update_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.other_phone_number.Should().Be(update_event.other_phone_number),

                        nothing:
                            () => { Assert.Fail("Audit Record was not find"); }

                    );
            }

        }

        [TestClass]
        public class on_remove_an_emergency_contact_other_phone_number
                                    : EmployeeEmergencyContactDetailsRemoveEventSpecification
        {
            [TestMethod]
            public void should_remove_emergency_contact_with_the_input_value_to_the_emergency_contact_details_audit_record()
            {
                var remove_event = fixture.create_event();
                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_emergency_contact_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.other_phone_number.Should().Be(remove_event.other_phone_number),

                        nothing:
                            () => { Assert.Fail("Audit Record was not find"); }
                    );
            }
        }
    }
}
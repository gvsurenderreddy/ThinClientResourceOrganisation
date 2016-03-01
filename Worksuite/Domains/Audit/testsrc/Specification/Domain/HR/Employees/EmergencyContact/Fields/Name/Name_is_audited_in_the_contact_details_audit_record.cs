using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Remove;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Updated;
using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Fields.Name

{
    public class Name_is_audited_in_the_contact_details_audit_record
                                       : AuditSpecification
    {
        [TestClass]
        public class On_create_an_emergency_contact
                              : EmployeeEmergencyContactDetailsCreatedEventSpecification
                                 
        {
            [TestMethod]
            public void should_write_name_with_the_input_value_to_the_employee_emergency_contact_details_audit_record()
            {
                var create_event = fixture.create_event();
                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_emergency_contact_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.name.Should().Be(create_event.name),

                        nothing:
                            () => { Assert.Fail("");}
                    );
            }
        }

        [TestClass]
        public class On_Uupdate_an_employee_emergency_contact
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
                            audit_record => audit_record.name.Should().Be(update_event.name),

                        nothing:
                            () => { Assert.Fail("Audit record was not find"); }
                    );
            }
        }

        [TestClass]
        public class On_remove_emergency_contact_details
                              : EmployeeEmergencyContactDetailsRemoveEventSpecification
        {
            [TestMethod]
            public void should_write_name_with_the_value_when_the_emergnecy_contact_was_removed_to_the_employee_emergency_contact_details_audit_record()
            {
                var remove_event = fixture.create_event();
                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_emergency_contact_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.name.Should().Be(remove_event.name),

                        nothing:
                            () => { Assert.Fail("Audit record not found"); }

                    );
            }
        }
    }

}
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Events.Updated;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ContactDetails.Fields.other
{
    public class Other_is_audited_in_the_contact_details_audit_record
    {
        [TestClass]
        public class On_create_employee
                        : EmployeeCreatedEventSpecification
        {
            [TestMethod]
            public void a_null_other_is_written_to_the_employee_contact_details_audit_record()
            {
                var crated_event = fixture.create_event();

                fixture.event_handler.handle(crated_event);

                fixture
                    .get_last_contact_details_audit_record_for(crated_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.other.Should().BeNull(),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestClass]
            public class On_update_contact_details
                            : EmployeeContactDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_other_is_written_to_the_employee_contact_details_audit_record()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_contact_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.other.Should().Be(update_event.other),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }
            }
        }
    }
}
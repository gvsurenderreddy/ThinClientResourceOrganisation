using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Fields.date_of_birth
{
    public class DateOfBirth_is_audited_in_the_personal_details_audit_record
    {
        [TestClass]
        public class On_create_employee
                            : EmployeeCreatedEventSpecification
        {
            [TestMethod]
            public void a_null_date_of_birth_is_written_to_the_employee_personal_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_personal_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.date_of_birth.Should().Be(null),

                        nothing:
                        () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_update_personal_details
                            : EmployeePersonalDetailsUpdatedEventSpecification
        {
            [TestMethod]
            public void the_date_of_birth_is_written_to_the_employee_personal_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_personal_details_audit_record_for(update_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.date_of_birth.Should().Be(update_event.date_of_birth),

                        nothing:
                            () => { Assert.Fail("Audit record not found"); }
                    );
            }
        }
    }
}
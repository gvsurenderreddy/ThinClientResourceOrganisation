using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Fields.ethnic_origin
{
    public class Ethnic_origin_is_audited_in_the_personal_details_audit_record
    {
        [TestClass]
        public class On_create_employee
                        : EmployeeCreatedEventSpecification
        {
            [TestMethod]
            public void a_null_ethnic_origin_id_is_written_to_the_employee_personal_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_personal_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.ethnic_origin_id.Should().Be(null),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void a_null_ethnic_origin_description_is_written_to_the_employee_personal_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_personal_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.ethnic_origin_description.Should().Be(null),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_employee_personal_details_update
                            : EmployeePersonalDetailsUpdatedEventSpecification
        {
            [TestMethod]
            public void ethnic_origin_id_is_written_to_the_employee_personal_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_personal_details_audit_record_for(update_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.ethnic_origin_id.Should().Be(update_event.ethnic_origin_id),

                        nothing:
                            () => { Assert.Fail("Audit record was not found when there should have been one."); }
                    );
            }

            [TestMethod]
            public void ethnic_origin_description_is_written_to_the_employee_personal_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_personal_details_audit_record_for(update_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.ethnic_origin_description.Should().Be(update_event.ethnic_origin_description),

                        nothing:
                            () => { Assert.Fail("Audit record was not found when there should have been one."); }
                    );
            }
        }
    }
}
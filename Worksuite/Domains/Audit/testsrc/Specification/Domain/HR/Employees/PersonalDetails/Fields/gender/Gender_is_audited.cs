using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Fields.gender
{
    public class Gender_is_audited_in_the_personal_details_audit_record
    {
        [TestClass]
        public class On_create_employee
                            : EmployeeCreatedEventSpecification
        {
            [TestMethod]
            public void a_null_gender_id_is_written_to_the_employee_personal_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_personal_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.gender_id.Should().Be(null),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void a_null_gender_description_is_written_to_the_employee_personal_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_personal_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.gender_description.Should().BeNull(),

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
            public void gender_id_is_written_to_the_employee_personal_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_personal_details_audit_record_for(update_event)
                    .Match(
                        has_value:
                            audit_record =>
                            {
                                audit_record.gender_id.Should().Be(update_event.gender_id);
                            },

                            nothing:
                                () => { Assert.Fail("Audit record was not found when there should have been one,  This is Bad!!!!"); }
                    );
            }

            [TestMethod]
            public void gender_description_is_written_to_the_employee_personal_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                fixture
                    .get_last_personal_details_audit_record_for(update_event)
                    .Match(
                        has_value:
                            audit_record =>
                            {
                                audit_record.gender_description.Should().Be(update_event.gender_description);
                            },

                            nothing:
                                () => { Assert.Fail("Audit record was not found when there should have been one,  This is Bad!!!!"); }
                    );
            }
        }
    }
}
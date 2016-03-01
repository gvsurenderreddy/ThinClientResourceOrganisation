using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Removed;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Fields.skill
{
    public class Skill_is_audited_in_the_skill_details_audit_record
    {
        [TestClass]
        public class On_employee_skill_creation
                            : EmployeeSkillDetailsCreatedEventSpecification
        {
            [TestMethod]
            public void should_write_skill_id_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_skill_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.skill_id.Should().Be(create_event.employee_skill_id),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_skill_description_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_skill_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.skill_description.Should().Be(create_event.employee_skill_description),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_skill_priority_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_skill_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.priority.Should().Be(create_event.priority),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_employee_skill_removal
                            : EmployeeSkillDetailsRemovedEventSpecification
        {
            [TestMethod]
            public void should_write_skill_id_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_skill_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.skill_id.Should().Be(remove_event.employee_skill_id),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_skill_description_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_skill_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.skill_description.Should().Be(remove_event.employee_skill_description),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_skill_priority_for_the_selected_skill_to_the_employee_skill_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_skill_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.priority.Should().Be(remove_event.priority),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }
    }
}
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Removed;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Fields.qualification
{
    public class Qualification_is_audited_in_the_qualification_details_audit_record
    {
        [TestClass]
        public class On_employee_skill_creation
                            : EmployeeQualificationDetailsCreatedEventSpecification
        {
            [TestMethod]
            public void should_write_qualification_id_for_the_selected_qualification_to_the_employee_qualification_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_qualification_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.qualification_id.Should().Be(create_event.employee_qualification_id),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_qualification_description_for_the_selected_qualification_to_the_employee_qualification_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_qualification_details_audit_record_for(create_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.qualification_description.Should().Be(create_event.employee_qualification_description),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_employee_skill_removal
                            : EmployeeQualificationDetailsRemovedEventSpecification
        {
            [TestMethod]
            public void should_write_qualification_id_for_the_selected_qualification_to_the_employee_qualification_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_qualification_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record => audit_record.qualification_id.Should().Be(remove_event.employee_qualification_id),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestMethod]
            public void should_write_qualification_description_for_the_selected_qualification_to_the_employee_qualification_details_audit_record
                ()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_qualification_details_audit_record_for(remove_event)
                    .Match(
                        has_value:
                            audit_record =>
                                audit_record.qualification_description.Should().Be(remove_event.employee_qualification_description),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }
    }
}
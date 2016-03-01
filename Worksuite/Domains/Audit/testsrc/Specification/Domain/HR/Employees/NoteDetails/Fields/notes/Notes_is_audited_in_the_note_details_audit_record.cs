using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Removed;
using WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.NoteDetails.Fields.notes
{
    public class Notes_is_audited_in_the_note_details_audit_record
    {
        [TestClass]
        public class On_create_an_employee_note
                        : EmployeeNoteDetailsCreatedEventSpecification
        {
            [TestMethod]
            public void should_write_note_with_the_input_value_to_the_employee_note_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_note_details_audit_record_for(create_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.notes.Should().Be(create_event.notes),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_update_an_employee_note
                        : EmployeeNoteDetailsUpdatedEventSpecification
        {
            [TestMethod]
            public void should_write_note_with_the_updated_value_to_the_employee_note_details_audit_record()
            {
                var update_event = fixture.create_event();

                fixture.event_handler.handle(update_event);

                var something = fixture
                    .get_last_note_details_audit_record_for(update_event);

                fixture
                    .get_last_note_details_audit_record_for(update_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.notes.Should().Be(update_event.notes),

                        nothing:
                            () => { Assert.Fail("Audit record not found."); }
                    );
            }
        }

        [TestClass]
        public class On_remove_an_employee_note
                        : EmployeeNoteDetailsRemovedEventSpecification
        {
            [TestMethod]
            public void should_write_note_with_the_value_when_the_note_was_removed_to_the_employee_note_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_note_details_audit_record_for(remove_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.notes.Should().Be(remove_event.notes),

                        nothing:
                            () => { Assert.Fail("Audit record not found."); }
                    );
            }
        }
    }
}
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.DocumentDetails.Events.Removed;
using WTS.WorkSuite.Audit.Domain.HR.Employees.DocumentDetails.Events.Uploaded;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.DocumentDetails.Fields.name
{
    public class Name_is_audited_in_the_document_details_audit_record
    {
        [TestClass]
        public class On_upload_of_an_employee_document
                        : EmployeeDocumentDetailsUploadedEventSpecification
        {
            [TestMethod]
            public void should_write_name_with_the_input_value_to_the_employee_document_details_audit_record()
            {
                var upload_event = fixture.create_event();

                fixture.event_handler.handle(upload_event);

                fixture
                    .get_last_document_details_audit_record_for(upload_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.name.Should().Be(upload_event.name),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }
        }

        [TestClass]
        public class On_remove_an_employee_document
                        : EmployeeDocumentDetailsRemovedEventSpecification
        {
            [TestMethod]
            public void should_write_name_with_the_value_when_the_document_was_removed_to_the_employee_document_details_audit_record()
            {
                var remove_event = fixture.create_event();

                fixture.event_handler.handle(remove_event);

                fixture
                    .get_last_employee_document_details_audit_record_for(remove_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.name.Should().Be(remove_event.name),

                        nothing:
                            () => { Assert.Fail("Audit record not found."); }
                    );
            }
        }
    }
}
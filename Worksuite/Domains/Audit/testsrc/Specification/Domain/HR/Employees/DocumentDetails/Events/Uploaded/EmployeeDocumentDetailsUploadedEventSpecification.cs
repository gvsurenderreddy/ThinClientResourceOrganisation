using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.DocumentDetails.Events.Uploaded
{
    public class EmployeeDocumentDetailsUploadedEventSpecification
                        : AuditSpecification
    {
        public EmployeeDocumentDetailsUploadedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeDocumentDetailsUploadedEventFixture();
        }
    }
}
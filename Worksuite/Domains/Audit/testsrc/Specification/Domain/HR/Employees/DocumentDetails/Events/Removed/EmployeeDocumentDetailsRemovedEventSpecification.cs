using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.DocumentDetails.Events.Removed
{
    public class EmployeeDocumentDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeDocumentDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeDocumentDetailsRemovedEventFixture();
        }
    }
}
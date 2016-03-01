using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ImageDetails.Events.Removed
{
    public class EmployeeImageDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeImageDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeImageDetailsRemovedEventFixture();
        }
    }
}
using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ImageDetails.Events.Updated
{
    public class EmployeeImageDetailsUpdatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeImageDetailsUpdatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeImageDetailsUpdatedEventFixture();
        }
    }
}
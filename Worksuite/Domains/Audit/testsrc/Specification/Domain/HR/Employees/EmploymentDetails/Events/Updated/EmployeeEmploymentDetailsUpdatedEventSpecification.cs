using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated
{
    public class EmployeeEmploymentDetailsUpdatedEventSpecification
                    : AuditSpecification
    {
        public EmploymentDetailsUpdatedFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmploymentDetailsUpdatedFixture();
        }
    }
}
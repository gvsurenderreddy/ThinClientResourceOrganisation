using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Removed
{
    public class EmployeeQualificationDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeQualificationDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeQualificationDetailsRemovedEventFixture();
        }
    }
}
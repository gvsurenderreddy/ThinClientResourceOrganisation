using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Created
{
    public class EmployeeQualificationDetailsCreatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeQualificationDetailsCreatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeQualificationDetailsCreatedEventFixture();
        }
    }
}
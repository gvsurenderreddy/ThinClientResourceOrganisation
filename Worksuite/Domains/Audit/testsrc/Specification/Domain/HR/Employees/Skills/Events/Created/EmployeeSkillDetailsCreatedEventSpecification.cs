using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Created
{
    public class EmployeeSkillDetailsCreatedEventSpecification
                        : AuditSpecification
    {
        public EmployeeSkillDetailsCreatedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeSkillDetailsCreatedEventFixture();
        }
    }
}
using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Removed
{
    public class EmployeeSkillDetailsRemovedEventSpecification
                        : AuditSpecification
    {
        public EmployeeSkillDetailsRemovedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeSkillDetailsRemovedEventFixture();
        }
    }
}
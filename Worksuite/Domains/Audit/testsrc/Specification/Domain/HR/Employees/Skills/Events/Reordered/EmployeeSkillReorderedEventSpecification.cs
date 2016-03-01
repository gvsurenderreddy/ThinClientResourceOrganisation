using WTS.WorkSuite.Audit.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Skills.Events.Reordered
{
    public class EmployeeSkillReorderedEventSpecification
                        : AuditSpecification
    {
        public EmployeeSkillReorderedEventFixture fixture { get; private set; }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new EmployeeSkillReorderedEventFixture();
        }
    }
}
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeSkills
{
    public class EmployeeSkillBuilder : IEntityBuilder<EmployeeSkill>
    {
        public EmployeeSkill entity { get { return employee_skill; } }

        public EmployeeSkillBuilder(EmployeeSkill the_employee_skill)
        {
            Guard.IsNotNull(the_employee_skill, "the_employee_skill");

            var employee_skill_identity_provider = new IntIdentityProvider<EmployeeSkill>();

            employee_skill = new EmployeeSkill
            {
                id = employee_skill_identity_provider.next(),
                skill = the_employee_skill.skill
            };
        }


        public EmployeeSkillBuilder skill(Skill value)
        {
            employee_skill.skill = value;
            return this;
        }

        public EmployeeSkillBuilder priority(int value)
        {
            employee_skill.priority = value;
            return this;
        }


        private readonly EmployeeSkill employee_skill;
    }
}
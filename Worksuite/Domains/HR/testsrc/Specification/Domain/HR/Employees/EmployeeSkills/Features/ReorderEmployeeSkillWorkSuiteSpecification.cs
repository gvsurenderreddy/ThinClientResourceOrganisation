using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features
{
    public class ReorderEmployeeSkillWorkSuiteSpecification
                    : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            skill_helper = DependencyResolver.resolve<SkillHelper>();
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            reorder_employee_skill = DependencyResolver.resolve<IReorderEmployeeSkill>();

            skill_one = skill_helper.add().description("skill 1").entity;
            skill_two = skill_helper.add().description("skill 2").entity;
            skill_three = skill_helper.add().description("skill 3").entity;
            skill_four = skill_helper.add().description("skill 4").entity;
            skill_five = skill_helper.add().description("skill 5").entity;
            skill_six = skill_helper.add().description("skill 6").entity;

            employee_skill_one = create_employee_skill().skill(skill_one).priority(1).entity;
            employee_skill_two = create_employee_skill().skill(skill_two).priority(2).entity;
            employee_skill_three = create_employee_skill().skill(skill_three).priority(3).entity;
            employee_skill_four = create_employee_skill().skill(skill_four).priority(4).entity;
            employee_skill_five = create_employee_skill().skill(skill_five).priority(5).entity;
            employee_skill_six = create_employee_skill().skill(skill_six).priority(6).entity;

            employee = employee_helper
                        .add()
                        .employee_skill(employee_skill_one)
                        .employee_skill(employee_skill_two)
                        .employee_skill(employee_skill_three)
                        .employee_skill(employee_skill_four)
                        .employee_skill(employee_skill_five)
                        .employee_skill(employee_skill_six)
                        .entity
                        ;
        }

        protected EmployeeSkillBuilder create_employee_skill()
        {
            return new EmployeeSkillBuilder(new EmployeeSkill());
        }

        protected EmployeeHelper employee_helper;
        protected SkillHelper skill_helper;
        protected IReorderEmployeeSkill reorder_employee_skill;

        protected Skill skill_one;
        protected Skill skill_two;
        protected Skill skill_three;
        protected Skill skill_four;
        protected Skill skill_five;
        protected Skill skill_six;

        protected EmployeeSkill employee_skill_one;
        protected EmployeeSkill employee_skill_two;
        protected EmployeeSkill employee_skill_three;
        protected EmployeeSkill employee_skill_four;
        protected EmployeeSkill employee_skill_five;
        protected EmployeeSkill employee_skill_six;

        protected Employee employee;
    }
}
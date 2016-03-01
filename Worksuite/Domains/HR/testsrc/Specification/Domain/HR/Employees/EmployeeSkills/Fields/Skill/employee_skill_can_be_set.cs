using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Fields.Skill
{
    [TestClass]
    public class skill_can_be_set : HRSpecification
    {
        #region"Create"

        [TestMethod]
        public void to_an_existing_skill_on_create()
        {
            var skill = skill_helper.add().description("skill").entity;

            var create_response = create_command.execute(new NewEmployeeSkillRequest
            {
                skill_id = skill.id,
                employee_id = employee.id
            });

            var employee_skill = employee.EmployeeSkills.Single(a => a.id == create_response.result.employee_skill_id);

            Assert.IsTrue(employee_skill.skill.id == skill.id);
        }

        [TestMethod]
        public void cannot_set_a_duplicate_entry_on_create()
        {
            var skill = skill_helper.add().description("skill").entity;

            employee_skill = employee_skill_builder.skill(skill).entity;

            employee = employee_helper.add()
                                       .employee_skill(employee_skill)
                                       .entity;

            var create_response = create_command.execute(new NewEmployeeSkillRequest
            {
                skill_id = skill.id,
                employee_id = employee.id
            });

            Assert.IsTrue(create_response.has_errors);
        }

        [TestMethod]
        public void cannot_be_set_to_a_hidden_one_on_create()
        {
            var skill = skill_helper.add().is_hidden(true).description("skill").entity;

            var create_response = create_command.execute(new NewEmployeeSkillRequest
            {
                skill_id = skill.id,
                employee_id = employee.id
            });

            Assert.IsTrue(create_response.has_errors);
        }

        #endregion

        protected override void test_setup()
        {
            base.test_setup();

            create_command = DependencyResolver.resolve<INewEmployeeSkill>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();

            employee_skill_builder = new EmployeeSkillBuilder(new EmployeeSkill());
            employee_helper = DependencyResolver.resolve<EmployeeHelper>();
            skill_helper = DependencyResolver.resolve<SkillHelper>();

            setup_employee_employee_skill();
        }

        private void setup_employee_employee_skill()
        {
            employee_skill = employee_skill_builder.skill(skill_helper.add().description("A skill").entity).entity;
            employee = employee_helper
                           .add().employee_skill(employee_skill)
                           .entity;
        }

        private INewEmployeeSkill create_command;

        private EmployeeSkillBuilder employee_skill_builder;
        private EmployeeHelper employee_helper;
        protected SkillHelper skill_helper;

        private Employee employee;
        private EmployeeSkill employee_skill;
        protected IEntityRepository<Employee> repository;
    }
}
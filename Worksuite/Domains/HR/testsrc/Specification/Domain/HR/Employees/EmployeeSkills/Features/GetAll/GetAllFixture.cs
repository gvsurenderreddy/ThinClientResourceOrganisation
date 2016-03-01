using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.GetAll;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.GetAll
{
    public class GetAllFixture : HRSpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            query = DependencyResolver.resolve<IGetAllEmployeeSkills>();
            repository = DependencyResolver.resolve<IEntityRepository<Employee>>();
            employee_skill_builder = new EmployeeSkillBuilder(new EmployeeSkill());
            skill_helper = DependencyResolver.resolve<SkillHelper>();

        }

        protected EmployeeBuilder add_employee()
        {
            var builder = new EmployeeBuilder(new Employee());

            repository.add(builder.entity);

            return builder;
        }

        protected SkillHelper skill_helper;
        protected EmployeeSkillBuilder employee_skill_builder;
        protected IGetAllEmployeeSkills query;
        protected IEntityRepository<Employee> repository;
    }
}

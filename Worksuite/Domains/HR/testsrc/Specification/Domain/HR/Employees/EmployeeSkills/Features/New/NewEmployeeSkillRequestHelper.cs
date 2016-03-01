using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.New
{
    public class NewEmployeeSkillRequestHelper : IRequestHelper<NewEmployeeSkillRequest>
    {
        public NewEmployeeSkillRequestHelper(EmployeeHelper the_employee_helper, SkillHelper the_skill_helper)
        {
            employee_helper = Guard.IsNotNull(the_employee_helper, "the_employee_helper");
            skill_helper = Guard.IsNotNull(the_skill_helper, "the_skill_helper");
        }

        public NewEmployeeSkillRequest given_a_valid_request()
        {
            var skill = skill_helper.add().description("skill").entity;

            //Create an Employee
            var employee = employee_helper.add().entity;

            return new NewEmployeeSkillRequest
            {
                employee_id = employee.id,
                skill_id = skill.id
            };

        }


        private EmployeeHelper employee_helper;
        private SkillHelper skill_helper;
    }
}
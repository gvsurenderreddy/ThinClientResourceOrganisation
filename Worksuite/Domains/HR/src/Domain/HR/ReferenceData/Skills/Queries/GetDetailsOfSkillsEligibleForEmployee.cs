using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries
{

    public class GetDetailsOfSkillsEligibleForEmployee : IGetDetailsOfSkillsEligibleForEmployee
    {
        public GetDetailsOfSkillsEligibleForEmployee(IQueryRepository<Employee> the_employee_repository
                                                    , IQueryRepository<Skill> the_skill_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            skill_repository = Guard.IsNotNull(the_skill_repository, "the_skill_repository");
        }

        public Response<IEnumerable<SkillDetails>> execute(EmployeeIdentity request)
        {
            var employee = employee_repository.Entities.Single(e => e.id == request.employee_id);

            var skills_assigned_to_employee = employee.EmployeeSkills.Select(s=>s.skill).ToList();


            var skills =
                skill_repository.Entities
                                .Where(r => !r.is_hidden)
                                .OrderBy(r => r.description)
                                .ToList()
                                .Where(r => !skills_assigned_to_employee.Any(a => a.id == r.id)).ToList();


            return new Response<IEnumerable<SkillDetails>>
            {
                result = skills.Select(r => new SkillDetails()
                {
                    id = r.id,
                    description = r.description,
                    is_hidden = r.is_hidden
                })
            };
        }


        private readonly IQueryRepository<Employee> employee_repository;
        private readonly IQueryRepository<Skill> skill_repository;
    }
}
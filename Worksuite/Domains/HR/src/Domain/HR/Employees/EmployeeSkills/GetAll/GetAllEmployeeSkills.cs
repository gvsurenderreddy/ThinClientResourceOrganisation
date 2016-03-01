using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.GetAll
{
    public class GetAllEmployeeSkills : IGetAllEmployeeSkills
    {
        public GetAllEmployeeSkills(IQueryRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IQueryRepository<Employee> repository;
        private Employee employee;


        public GetAllEmployeeSkillsResponse execute(EmployeeIdentity request)
        {
            employee = repository
                      .Entities
                      .Single(e => e.id == request.employee_id);

            return new GetAllEmployeeSkillsResponse
            {
                result = employee.EmployeeSkills.OrderBy(ec => ec.priority).Select(ec => new EmployeeSkillDetails
                {
                    employee_id = request.employee_id,
                    employee_skill_id = ec.id,
                    skill = ec.skill == null ? null : ec.skill.description,
                    priority = ec.priority
                }),
            };
        }
    }
}
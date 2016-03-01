using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder
{
    /// <summary>
    /// This is unlike any other GetRequest Query
    /// In this one, we already have the request, 
    /// we just need details added to the request.
    /// </summary>
    public class GetReorderEmployeeSkillRequestDetails : IGetReorderEmployeeSkillRequestDetails
    {
        public GetReorderEmployeeSkillRequestDetails(IEntityRepository<Employee> the_employee_repository)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "theemployee_repository");
        }

        public Response<ReorderEmployeeSkillDetails> execute(ReorderEmployeeSkillRequest request)
        {
            var employee = employee_repository
                                .Entities
                                .Single(e => e.id == request.employee_id)
                                ;
            var employee_skill = employee
                                        .EmployeeSkills
                                        .Single(em => em.id == request.employee_skill_id)
                                        ;

            Guard.IsNotNull(employee_skill.skill, "employee_skill.skill");

            return new Response<ReorderEmployeeSkillDetails>
            {
                result = new ReorderEmployeeSkillDetails
                {
                    employee_skill_id = request.employee_skill_id,
                    employee_id = request.employee_id,
                    priority = request.priority,
                    skill = employee_skill.skill.description,
                    current_priority = employee_skill.priority
                }
            };
        }

        private readonly IEntityRepository<Employee> employee_repository;
    }
}
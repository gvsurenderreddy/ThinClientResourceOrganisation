using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public class GetNewEmployeeSkillRequest : IGetNewEmployeeSkillRequest
    {

        public NewEmployeeSkillRequest execute(EmployeeIdentity request)
        {
            return new NewEmployeeSkillRequest
                {
                    employee_id = request.employee_id,
                };
        }
    }
}
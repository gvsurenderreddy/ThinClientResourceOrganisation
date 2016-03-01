using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.GetAll
{
    public interface IGetAllEmployeeSkills : IQuery<EmployeeIdentity, GetAllEmployeeSkillsResponse> { }
}
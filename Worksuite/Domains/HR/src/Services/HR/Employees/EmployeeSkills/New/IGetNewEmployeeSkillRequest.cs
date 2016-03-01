using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public interface IGetNewEmployeeSkillRequest : ICommand<EmployeeIdentity,NewEmployeeSkillRequest> { }
}
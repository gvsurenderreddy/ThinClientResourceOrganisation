using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Remove
{

    public interface IRemoveEmployeeSkill
                        : IResponseCommand<EmployeeSkillIdentity, RemoveEmployeeSkillResponse> { }
}
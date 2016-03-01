using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder
{
    public interface IReorderEmployeeSkill
                        :   ICommand<ReorderEmployeeSkillRequest, ReorderEmployeeSkillResponse> {}
}

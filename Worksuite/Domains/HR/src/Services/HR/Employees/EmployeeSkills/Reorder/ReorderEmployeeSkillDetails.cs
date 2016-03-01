
namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder
{
    public class ReorderEmployeeSkillDetails
                        : ReorderEmployeeSkillRequest
    {
        public string skill { get; set; }
        public int current_priority { get; set; }
    }
}
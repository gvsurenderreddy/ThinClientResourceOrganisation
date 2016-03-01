namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events
{
    public class EmployeeSkillRemovedEvent
                        : EmployeeSkillIdentity
    {
        public string employee_skill_description { get; set; }

        public int priority { get; set; }
    }
}
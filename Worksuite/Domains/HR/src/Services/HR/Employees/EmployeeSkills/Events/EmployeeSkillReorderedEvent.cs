namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events
{
    /// <summary>
    ///  Event that is published when an employee skill is reordered.
    ///     This is an abstract class that has all the common
    ///     properties for an employee skill reorder event.
    /// </summary>
    public abstract class EmployeeSkillReorderedEvent
                        : EmployeeSkillIdentity
    {
        public string skill_description { get; set; }

        public int priority { get; set; }
    }

    /// <summary>
    ///     This is a specific implementation for auto reorder event, derived from employee skill reordered event.
    /// </summary>
    public class EmployeeSkillAutoReorderedEvent
                        : EmployeeSkillReorderedEvent { }

    /// <summary>
    ///     This is a specific implementation for manual reorder event, derived from employee skill reordered event.
    /// </summary>
    public class EmployeeSkillManualReorderedEvent
                        : EmployeeSkillReorderedEvent { }
}
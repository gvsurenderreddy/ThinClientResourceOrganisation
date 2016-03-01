namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events
{
    public class EmployeeQualificationRemovedEvent
                        : EmployeeQualificationIdentity
    {
        public string employee_qualification_description { get; set; }
    }
}
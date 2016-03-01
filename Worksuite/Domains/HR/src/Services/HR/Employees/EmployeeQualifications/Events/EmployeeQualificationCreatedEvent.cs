namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events
{
    public class EmployeeQualificationCreatedEvent
                        : EmployeeQualificationIdentity
    {
        public string employee_qualification_description { get; set; }
    }
}
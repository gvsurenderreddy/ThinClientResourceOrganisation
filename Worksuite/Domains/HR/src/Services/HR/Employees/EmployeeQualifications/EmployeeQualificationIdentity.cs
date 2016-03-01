using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications
{
    public class EmployeeQualificationIdentity
                        : EmployeeIdentity
    {
        public int employee_qualification_id { get; set; }
    }
}
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public class NewEmployeeQualificationRequest
                        : EmployeeIdentity
    {
        public int qualification_id { get; set; }
    }
}
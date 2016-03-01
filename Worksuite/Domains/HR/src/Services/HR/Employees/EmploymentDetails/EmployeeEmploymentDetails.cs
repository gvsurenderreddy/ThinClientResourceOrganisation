using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails
{
    public class EmployeeEmploymentDetails : EmployeeIdentity
    {
        public string employeeReference { get; set; }

        public string location_description { get; set; }

        public string job_description { get; set; }
    }
}
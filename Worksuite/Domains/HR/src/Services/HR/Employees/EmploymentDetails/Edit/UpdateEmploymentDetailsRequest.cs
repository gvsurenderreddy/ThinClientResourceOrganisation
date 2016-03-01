using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit
{
    public class UpdateEmploymentDetailsRequest : EmployeeIdentity
    {
        public string employeeReference { get; set; }

        public int location_id { get; set; }

        public int job_title_id { get; set; }
    }
}
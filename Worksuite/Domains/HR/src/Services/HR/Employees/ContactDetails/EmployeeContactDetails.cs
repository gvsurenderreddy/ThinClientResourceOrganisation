
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.ContactDetails
{
    public class EmployeeContactDetails : EmployeeIdentity
    {
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string other { get; set; }
    }
}

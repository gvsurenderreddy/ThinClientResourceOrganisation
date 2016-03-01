using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts
{
    public class EmergencyContactIdentity : EmployeeIdentity
    {
        public int emergency_contact_id { get; set; } 
    }
}
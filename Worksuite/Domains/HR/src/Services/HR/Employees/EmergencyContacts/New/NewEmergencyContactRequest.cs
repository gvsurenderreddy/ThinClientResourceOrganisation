using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public class NewEmergencyContactRequest : EmployeeIdentity
    {
        public string name { get; set; }
        public int relationship_id { get; set; }
        public string primary_phone_number { get; set; }
        public string other_phone_number { get; set; }
    }
}   
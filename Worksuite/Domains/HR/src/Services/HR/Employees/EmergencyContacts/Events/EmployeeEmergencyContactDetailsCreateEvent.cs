using WTS.WorkSuite.HR.HR.ReferenceData;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events
{
    public class EmployeeEmergencyContactDetailsCreateEvent
                             : EmergencyContactIdentity {

       public string name { get; set; }
       public  int? relationship_id { get; set; }
       public string primary_phone_number { get; set; }
       public string other_phone_number { get; set; }
       public int priority { get; set; }
    }
}
namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events
{
    public class EmployeeEmergencyContactReorderedEvent
                             : EmergencyContactIdentity
    {
        public string name { get; set; }
        public string primary_phone_number { get; set; }
        public string other_phone_number { get; set; }
        public int? relationship_id { get; set; }
        public int priority { get; set; }
    }

    public class EmployeeEmergencyContactAutoReorderedEvent
                           : EmployeeEmergencyContactReorderedEvent { }

    public class EmployeeEmergencyContactManualReorderedEvent
                         : EmployeeEmergencyContactReorderedEvent { }
}
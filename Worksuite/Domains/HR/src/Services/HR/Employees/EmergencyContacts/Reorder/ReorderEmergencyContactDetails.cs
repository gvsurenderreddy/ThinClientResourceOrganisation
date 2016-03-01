namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder
{
    public class ReorderEmergencyContactDetails
                        : ReorderEmergencyContactRequest
    {
        public string name { get; set; }
        public string relationship { get; set; }
        public string primary_phone_number { get; set; }
        public string other_phone_number { get; set; }
        public int current_priority { get; set; }
    }
}
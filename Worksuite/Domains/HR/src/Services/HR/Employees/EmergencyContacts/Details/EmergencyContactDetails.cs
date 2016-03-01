namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Details
{
    public class EmergencyContactDetails : EmergencyContactIdentity
    {
        public virtual string name { get; set; }
        public virtual string relationship { get; set; }
        public virtual string primary_phone_number { get; set; }
        public virtual string other_phone_number { get; set; }
        public virtual string priority { get; set; }
    }
}
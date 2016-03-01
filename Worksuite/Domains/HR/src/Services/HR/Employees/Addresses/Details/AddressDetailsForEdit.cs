using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Details
{
    public class AddressDetailsForEdit : AddressIdentity
    {
        public string number_or_Name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
    }
}
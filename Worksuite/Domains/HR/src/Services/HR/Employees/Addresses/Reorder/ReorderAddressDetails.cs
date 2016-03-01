
namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public class ReorderAddressDetails : ReorderAddressRequest
    {
        public string number_or_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public int current_priority { get; set; }
    }
}

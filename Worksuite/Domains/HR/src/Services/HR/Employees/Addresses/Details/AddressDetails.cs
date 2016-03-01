using System.Collections.Generic;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Details
{
    public class AddressDetails : AddressIdentity
    {
        public IEnumerable<string> lines { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string priority { get; set; }
    }
}
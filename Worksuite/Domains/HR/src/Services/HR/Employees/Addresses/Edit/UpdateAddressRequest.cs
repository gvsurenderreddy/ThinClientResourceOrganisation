using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Edit {

    public class UpdateAddressRequest 
                    : AddressIdentity 
                    , IPostalAddress {

        public string number_or_name { get; set; }
        public string line_one { get; set; }
        public string line_two { get; set; }
        public string line_three { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string current_priority { get; set; }
    }
}
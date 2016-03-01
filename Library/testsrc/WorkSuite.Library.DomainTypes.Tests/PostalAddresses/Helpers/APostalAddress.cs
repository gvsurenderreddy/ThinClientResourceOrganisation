using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers {

    class APostalAddress
        : IPostalAddress {

        public string number_or_name { get; set; }
        public string line_one { get; set; }
        public string line_two { get; set; }
        public string line_three { get; set; }
        public string county { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }

    }

}
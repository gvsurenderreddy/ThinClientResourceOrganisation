using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;

namespace WTS.WorkSuite.HR.HR {

    public class Address 
                    : BaseEntity<int>
                    , IPostalAddress {

        public virtual string number_or_name { get; set; }
        public virtual string line_one { get; set; }
        public virtual string line_two { get; set; }
        public virtual string line_three { get; set; }
        public virtual string county { get; set; }
        public virtual string country { get; set; }
        public virtual string postcode { get; set; }
        public virtual int priority { get; set; }
    }
}
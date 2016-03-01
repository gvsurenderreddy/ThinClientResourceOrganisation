using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers {

    public class When {
        
        public When the_address_is_sanitised () {

            var sanitiser = new PostalAddressSanitiser();

            sanitiser.sanitise( address );

            return this;
        }

        public Then then() {
            return new Then( address );
        }

        public When
                ( IPostalAddress  the_address ) {
            
            address = Guard.IsNotNull( the_address, "the_address" );
        }

        private readonly IPostalAddress address;
    }

}
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique {
    public class When {

        public When the_address_is_validated () {

            var validator = new PostalAddressIsUniqueValidator( new UnitTestsPostalAddressIsUniqueValidatorSettings() );

            error_messages = validator.validate( new PostalAddressIsUniqueRequest {
                address = address,
                addresses = addresses,
            });
            return this;

        }

        public Then then ( ) {
            
            return new Then( error_messages );
        }

        public When 
                ( IPostalAddress the_address
                , IEnumerable<IPostalAddress> the_addresses ) {

            address = the_address;
            addresses = the_addresses;
        }

        private readonly IPostalAddress address;
        private readonly IEnumerable<IPostalAddress> addresses;

        private IEnumerable<ResponseMessage> error_messages;
    }

}
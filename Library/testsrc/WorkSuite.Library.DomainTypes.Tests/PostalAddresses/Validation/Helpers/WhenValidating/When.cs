using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    class When {

        public When the_address_is_validated () {

            var validator = new PostalAddressValidator
                                    ( new UnitTestNumberOrNameValidatorSettings( )
                                    , new UnitTestAddressLineValidationSettings( )
                                    , new UnitTestAddressLineValidationSettings( )
                                    , new UnitTestAddressLineValidationSettings()
                                    , new UnitTestAddressLineValidationSettings( ) 
                                    , new UnitTestAddressLineValidationSettings( ) 
                                    , new UnitTestPostcodeValidatorSettings( ) );
                
           error_messages.AddRange( validator.validate( postal_address ));
           return this;
        }

        public Then then ( ) {
            return new Then( error_messages );
        }

        public When ( APostalAddress the_postal_address ) {
                
            postal_address = the_postal_address;
        }

        private readonly APostalAddress postal_address = new APostalAddress(  );
        private readonly List<ResponseMessage> error_messages = new List<ResponseMessage>(); 
    }

}
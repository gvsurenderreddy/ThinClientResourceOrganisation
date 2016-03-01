using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.country {

    [TestClass]
    public class county_is_converted_to_null_if_an_empty_string 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void whitespace_is_converted_to_null ( ) {

            this
                .given
                .country( given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .country_is( null );
        }

    }

}
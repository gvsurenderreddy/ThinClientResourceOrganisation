using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.country {

    [TestClass]
    public class country_is_converted_to_null_if_just_whitespace 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void empty_string_is_converted_to_null ( ) {

            this
                .given
                .country( "" )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .country_is( null );
        }

    }

}
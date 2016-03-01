using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.county {

    [TestClass]
    public class county_is_converted_to_null_if_just_whitespace 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void empty_string_is_converted_to_null ( ) {

            this
                .given
                .county( "" )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .county_is( null );
        }

    }

}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.postcode {

    [TestClass]
    public class postcode_has_leading_and_trailing_whitespace_trimmed 
                    : PostalAddressSanitiserSpecification {

        const string expected_value = "a value";

        [TestMethod]
        public void leading_whitespace_is_trimmed () {
            
            this
                .given
                .postcode( given.whitespace + expected_value )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .postcode_is( expected_value.ToUpper() )
                ;
        }


        [TestMethod]
        public void trailling_whitespace_is_trimmed () {
            
            this
                .given
                .postcode( expected_value + given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .postcode_is( expected_value.ToUpper() )
                ;
        }
    }
}
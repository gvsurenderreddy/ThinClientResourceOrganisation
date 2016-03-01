using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.line_one {

    [TestClass]
    public class line_one_has_leading_and_trailing_whitespace_trimmed 
                    : PostalAddressSanitiserSpecification {

        const string expected_value = "a value";

        [TestMethod]
        public void leading_whitespace_is_trimmed () {
            
            this
                .given
                .line_one( given.whitespace + expected_value )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_one_is( expected_value )
                ;
        }


        [TestMethod]
        public void trailling_whitespace_is_trimmed () {
            
            this
                .given
                .line_one( expected_value + given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_one_is( expected_value )
                ;
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.line_three {

    [TestClass]
    public class line_three_is_converted_to_null_if_an_empty_string 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void whitespace_is_converted_to_null ( ) {

            this
                .given
                .line_three( given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_three_is( null );
        }

    }

}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.line_three {

    [TestClass]
    public class line_three_is_converted_to_null_if_just_whitespace 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void empty_string_is_converted_to_null ( ) {

            this
                .given
                .line_three( "" )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_three_is( null );
        }

    }

}
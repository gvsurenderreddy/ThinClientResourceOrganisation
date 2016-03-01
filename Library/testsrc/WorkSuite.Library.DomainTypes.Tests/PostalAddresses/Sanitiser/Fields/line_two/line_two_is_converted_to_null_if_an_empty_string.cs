using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.line_two {

    [TestClass]
    public class line_two_is_converted_to_null_if_just_whitespace 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void empty_string_is_converted_to_null ( ) {

            this
                .given
                .line_two( "" )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_two_is( null );
        }

    }

}
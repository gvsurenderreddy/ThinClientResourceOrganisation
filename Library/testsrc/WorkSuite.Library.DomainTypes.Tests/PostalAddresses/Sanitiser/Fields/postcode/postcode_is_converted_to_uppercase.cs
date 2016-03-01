using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.postcode {

    [TestClass]
    public class postcode_is_converted_to_null_if_an_empty_string 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void whitespace_is_converted_to_null ( ) {

            this
                .given
                .postcode( given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .postcode_is( null );
        }

    }

}
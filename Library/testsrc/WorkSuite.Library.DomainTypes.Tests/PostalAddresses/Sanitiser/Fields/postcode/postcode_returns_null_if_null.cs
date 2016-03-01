using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.postcode {

    [TestClass]
    public class postcode_returns_null_if_null 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void null_is_returned_as_null ( ) {

            this
                .given
                .postcode( null )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .postcode_is( null );
        }
    }
}
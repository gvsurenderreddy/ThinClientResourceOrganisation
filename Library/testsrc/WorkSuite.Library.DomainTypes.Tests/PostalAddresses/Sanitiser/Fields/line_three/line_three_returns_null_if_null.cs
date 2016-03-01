using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.line_three {

    [TestClass]
    public class line_three_returns_null_if_null 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void null_is_returned_as_null ( ) {

            this
                .given
                .line_three( null )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .line_three_is( null );
        }
    }
}
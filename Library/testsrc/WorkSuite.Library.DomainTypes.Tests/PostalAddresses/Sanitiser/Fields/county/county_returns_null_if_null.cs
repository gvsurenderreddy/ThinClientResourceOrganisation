using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.county {

    [TestClass]
    public class county_returns_null_if_null 
                    : PostalAddressSanitiserSpecification {
        
        [TestMethod]
        public void null_is_returned_as_null ( ) {

            this
                .given
                .county( null )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .county_is( null );
        }

    }

}
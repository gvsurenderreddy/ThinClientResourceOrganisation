using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.postcode {

    [TestClass]
    public class postcode_is_converted_to_uppercase 
                    : PostalAddressSanitiserSpecification {

        const string a_value = "abcdefghijklmnopqrstuvwxyz";
        
        [TestMethod]
        public void whitespace_is_converted_to_null ( ) {

            this
                .given
                .postcode( a_value )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .postcode_is( a_value.ToUpper() );
        }

    }

}
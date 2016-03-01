using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.number_or_name {

    [TestClass]
    public class number_or_name_is_converted_to_null_if_just_whitespace
                    : PostalAddressSanitiserSpecification {


        [TestMethod]
        public void whitespace_is_converted_to_null ( ) {
            
            this
                .given
                .name_or_number( given.whitespace )

                .when()
                .the_address_is_sanitised()

                .then()
                .number_or_name_is( null )
                ;
        }
         

    }

}
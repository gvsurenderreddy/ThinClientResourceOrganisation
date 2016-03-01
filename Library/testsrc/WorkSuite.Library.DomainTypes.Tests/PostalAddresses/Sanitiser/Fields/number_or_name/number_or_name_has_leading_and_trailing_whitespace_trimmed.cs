using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Fields.number_or_name {

    [TestClass]
    public class number_or_name_has_leading_and_trailing_whitespace_trimmed 
                    : PostalAddressSanitiserSpecification {

        const string expected_value = "a value";

        [TestMethod]
        public void leading_whitespace_is_trimmed () {
            
            this
                .given
                .name_or_number( given.whitespace + expected_value )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .number_or_name_is( expected_value )
                ;
        }


        [TestMethod]
        public void trailling_whitespace_is_trimmed () {
            
            this
                .given
                .name_or_number( expected_value + given.whitespace )

                .when(  )
                .the_address_is_sanitised(  )

                .then()
                .number_or_name_is( expected_value )
                ;
        }
         

    }

}
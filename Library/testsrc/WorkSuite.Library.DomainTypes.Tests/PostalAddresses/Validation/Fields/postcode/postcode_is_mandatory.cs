using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Fields.postcode {

    [TestClass]
    public class psotcode_is_mandatory 
                    : PostalAddressValidatorSpecification {

        [TestMethod]
        public void retrun_an_error_if_an_empty_string ( ) {

            verify( string.Empty );

        }

        [TestMethod]
        public void returns_an_error_if_null ( ) {
            verify( null );
        }

        [TestMethod]
        public void retruns_an_erro_if_just_whitespaces ( ) {
            verify( " \t\n\r" );            
        }


        private void verify 
                        ( string field_value ) {

            this
                .given
                .a_valid_postal_address(  )
                .postcode( field_value )

                .when()
                .the_address_is_validated(  )

                .then()
                .postcode_is_madatory_error_is_reported ()
                ;            
        }
    }
}
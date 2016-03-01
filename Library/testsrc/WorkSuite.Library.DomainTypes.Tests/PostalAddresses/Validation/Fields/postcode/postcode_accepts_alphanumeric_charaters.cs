using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Fields.postcode {

    [TestClass]
    public class postcode_accepts_alphanumeric_charaters 
                    : PostalAddressValidatorSpecification {

        // Note - I was not really sure how to test this so I am
        //        just demonstrating that it accepts a postcode with,
        //        an alphabetic character, a digit, and that
        //        a character that is not alpha numeric. 


        [TestMethod]
        public void postcode_accepts_alphabetic_charaters ( ) {            
            
            var test = given_a_postcode_that_includes_an_alphabetic_character();

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .no_error_are_reported()
                ;
        }

        [TestMethod]
        public void postcode_accepts_digits ( ) {            
            
            var test = given_a_postcode_that_includes_a_digit();

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .no_error_are_reported()
                ;
        }

        [TestMethod]
        public void reports_an_error_if_a_non_alphanumeric_is_found ( ) {            
            
            var test = given_a_postcode_that_includes_a_non_alphanumeric_character ();

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .postcode_contains_invalid_characters_error_is_reported ()
                ;
        }

        
        private string given_a_postcode_that_includes_an_alphabetic_character () {
            return substitute_postcode_charater( 'A' );
        }

        private string given_a_postcode_that_includes_a_digit () {
            return substitute_postcode_charater( '1' );
        }

        private string given_a_postcode_that_includes_a_non_alphanumeric_character () {
            return substitute_postcode_charater( '#' );
        }

        private string substitute_postcode_charater
                        ( char substitute_with ) {

            var result = new StringBuilder(given.a_string_that_is_the_maximum_postcode_length());
            result[ result.Length - 2 ] = substitute_with;

            return result.ToString();            
        }

        //[TestMethod]
        //public void spaces_inside_the_postcode_are_ignored ( ) {

        //    var test = get_maximum_length_postcode_spaces_inside_it();  

        //    this
        //        .given
        //        .a_valid_postal_address(  )
        //        .postcode( test )

        //        .when( )
        //        .the_address_is_validated(  )

        //        .then( )
        //        .no_error_are_reported( )
        //        ;
        //}

        //[TestMethod]
        //public void does_not_report_an_error_when_the_value_is_on_the_boundary_for_the_maximum_number_of_charaters ( ) {            
            
        //    var test = given.a_string_that_is_the_maximum_postcode_length();

        //    this
        //        .given
        //        .a_valid_postal_address(  )
        //        .postcode( test  )

        //        .when(  )
        //        .the_address_is_validated(  )

        //        .then(  )
        //        .no_error_are_reported(  )
        //        ;
        //}

        private string get_maximum_length_postcode_spaces_inside_it () {
            var result = new StringBuilder(  given.a_string_that_is_the_maximum_postcode_length());

            result.Insert( result.Length - 2, ' ' );
            return result.ToString();
        }
    }

}
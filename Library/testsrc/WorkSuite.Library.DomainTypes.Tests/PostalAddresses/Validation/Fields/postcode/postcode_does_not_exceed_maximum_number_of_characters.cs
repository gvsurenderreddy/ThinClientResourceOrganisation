using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Fields.postcode {

    [TestClass]
    public class postcode_does_not_exceed_maximum_number_of_characters 
                    : PostalAddressValidatorSpecification {


        [TestMethod]
        public void reports_an_error_when_max_number_of_charaters_is_exceeded ( ) {            
            
            var test = given.a_string_that_is_the_maximum_postcode_length();

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test + "x" )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .postcode_exceeds_it_maximum_size_error_is_reported()
                ;
        }

        [TestMethod]
        public void spaces_inside_the_postcode_are_ignored ( ) {

            var test = get_maximum_length_postcode_spaces_inside_it();  

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test )

                .when( )
                .the_address_is_validated(  )

                .then( )
                .no_error_are_reported( )
                ;
        }

        [TestMethod]
        public void does_not_report_an_error_when_the_value_is_on_the_boundary_for_the_maximum_number_of_charaters ( ) {
            
            var test = given.a_string_that_is_the_maximum_postcode_length();

            this
                .given
                .a_valid_postal_address(  )
                .postcode( test  )

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .no_error_are_reported(  )
                ;
        }

        private string get_maximum_length_postcode_spaces_inside_it () {
            var result = new StringBuilder(  given.a_string_that_is_the_maximum_postcode_length());

            result.Insert( result.Length - 2, ' ' );
            return result.ToString();
        }
    }

}
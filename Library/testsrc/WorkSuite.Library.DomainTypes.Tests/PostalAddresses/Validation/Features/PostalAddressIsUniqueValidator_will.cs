using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Features {

    [TestClass]
    public class PostalAddressIsUniqueValidator_will 
                    : PostalAddressIsUniqueValidatorSpecification {
        
        [TestMethod]
        public void reports_an_error_if_the_an_duplicate_is_found () {

            this
                .given
                .an_address_that_already_exists()

                .when()
                .the_address_is_validated(  )

                .then()
                .address_with_same_number_or_name_is_reported()
                .address_with_same_postcode_is_reported()
                ;
        }

        [TestMethod]
        public void does_not_report_any_errors_if_the_address_is_not_in_the_collection ( ) {
            
            this
                .given
                .an_address_that_does_not_already_exist()

                .when()
                .the_address_is_validated(  )

                .then()
                .no_error_are_reported()
                ;

        }

        [TestMethod]
        public void interior_spaces_in_the_postcode_are_stripped_for_comparison () {
            
            this
                .given
                .a_collection_with_the_valid_postal_address_without_a_space_in_the_post_code()

                .when(  )
                .the_address_is_validated(  )

                .then(  )
                .address_with_same_number_or_name_is_reported(  )
                .address_with_same_postcode_is_reported(  )
                ;

        }

        [TestMethod]
        public void null_address_fields_are_handled ( ) {

            this
                .given
                .a_postal_address_with_all_fields_set_to_null(  )

                .when(  )
                .the_address_is_validated(  )
                ;        
        }

        [TestMethod]
        public void null_addresses_fields_are_handled () {
            
            this
                .given
                .a_collection_with_an_address_with_all_fields_set_to_null()

                .when(  )
                .the_address_is_validated(  )
                ;
        }

    }
}
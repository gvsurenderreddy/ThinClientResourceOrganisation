using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique {

    public class Given
                    : GivenAPostalAddress<When> {


        public Given an_address_that_already_exists () {

            this.a_valid_postal_address();

            postal_addresses = new List<IPostalAddress> {
                postal_address,
            };
            return this;
        }

        public Given a_collection_with_an_address_with_all_fields_set_to_null () {
            
            postal_addresses = new List<IPostalAddress> {
                new APostalAddress {
                    number_or_name = null,
                    line_one = null,
                    line_two = null,
                    line_three = null,
                    county = null,
                    country = null,
                    postcode = null,
                }
            };
            return this;            
        }
        
        public Given a_collection_with_the_valid_postal_address_without_a_space_in_the_post_code () {



            postal_addresses = new List<IPostalAddress> {
                new APostalAddress {
                    number_or_name = postal_address.number_or_name,
                    line_one = postal_address.line_one,
                    line_two = postal_address.line_two,
                    line_three = postal_address.line_three,
                    county = postal_address.county,
                    country = postal_address.country,
                    postcode = postal_address.postcode.Replace( " ", "" ),
                }
            };
            return this;
        }


        public Given an_address_that_does_not_already_exist ( ) {
            
            this.a_valid_postal_address(  );

            postal_addresses = new List<IPostalAddress> {
                new APostalAddress {
                    number_or_name = postal_address.number_or_name + "e",
                    postcode = postal_address.postcode + "e",
                }
            };
            return this;
        }

        public override When when () {

            return new When
                        ( postal_address
                        , postal_addresses
                        );
        }

        private List<IPostalAddress> postal_addresses = new List<IPostalAddress>();
    }
}
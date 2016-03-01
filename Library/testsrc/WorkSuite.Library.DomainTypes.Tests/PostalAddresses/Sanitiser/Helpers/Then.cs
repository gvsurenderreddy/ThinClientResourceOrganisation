using FluentAssertions;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers {

    public class Then {

        public void number_or_name_is 
                        ( string value ) {

            verify( value, address.number_or_name );
        }


        public void line_one_is 
                        ( string value ) {

            verify( value, address.line_one );
        }

        public void line_two_is 
                        ( string value ) {
            
            verify( value, address.line_two );
        }

        public void line_three_is 
                        ( string value ) {

            verify( value, address.line_three );
        }

        public void county_is 
                        ( string value ) {

            verify( value, address.county );
        }

        public void country_is 
                        ( string value ) {

            verify( value, address.country );
        }
        
        public void postcode_is 
                        ( string value ) {

            verify( value, address.postcode );
        }


        public Then 
                ( IPostalAddress the_address ) {
            
            address = the_address;
        }

        private void verify 
                        ( string expected 
                        , string actual ) {
            
            actual.Should(  ).Be( expected );
        }

        private IPostalAddress address;

    }

}
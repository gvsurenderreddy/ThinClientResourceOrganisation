using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers {

    public abstract class GivenAPostalAddress<W> {

        public string a_string_that_is_the_maximum_address_line_length ( ) {
            return new string( 'x', address_line_settings.max_length );
        }
        
        public string a_string_that_is_the_maximum_postcode_length () {
            return new string( 'x', postcode_settings.max_length_of_postcode );
        }

        public GivenAPostalAddress<W> a_valid_postal_address ( ) {
                
            return this;
        }

        public GivenAPostalAddress<W> a_postal_address_with_all_fields_set_to_null ( ) {

            postal_address.number_or_name = null;
            postal_address.line_one = null;
            postal_address.line_two = null;
            postal_address.line_three = null;
            postal_address.county = null;
            postal_address.country = null;
            postal_address.postcode = null;
            return this;
        }


        public GivenAPostalAddress<W> name_or_number
                                        ( string value ) {

            postal_address.number_or_name = value;
            return this;
        }

        public GivenAPostalAddress<W> line_one 
                        ( string value ) {

            postal_address.line_one = value;
            return this;
        }

        public GivenAPostalAddress<W> line_two 
                        ( string value ) {

            postal_address.line_two = value;
            return this;
        }

        public GivenAPostalAddress<W> line_three
                        ( string value ) {

            postal_address.line_three = value;
            return this;
        }

        public GivenAPostalAddress<W> county 
                        ( string value ) {

            postal_address.county = value;
            return this;
        }

        public GivenAPostalAddress<W> country
                        ( string value ) {

            postal_address.country = value;
            return this;
        }

        public GivenAPostalAddress<W> postcode 
                        ( string value ) {

            postal_address.postcode = value;
            return this;
        }

        public abstract W when ();


        internal readonly APostalAddress postal_address = new APostalAddress {
            number_or_name = "name or number",
            line_one = "line one",
            line_two = "line two",
            line_three = "line three",
            county = "county",
            country = "country",
            postcode = "LA6 1EN",
        };

        private readonly UnitTestAddressLineValidationSettings address_line_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestPostcodeValidatorSettings postcode_settings = new UnitTestPostcodeValidatorSettings(  );

    }
}
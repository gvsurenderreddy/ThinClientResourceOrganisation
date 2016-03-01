using System.Collections.Generic;
using FluentAssertions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    class Then {

        public Then no_error_are_reported () {
            
            all_error_messages.Should().BeEmpty();
            return this;
        }

        public Then name_or_number_is_madatory_error_is_reported ( ) {
            
            name_or_number_error_messages.Should(  ).Contain( number_or_name_settings.mandatory_field_not_specified_error_message );
            return this;
        }

        public Then name_or_number_exceeds_it_maximum_size_error_is_reported ( ) {
            
            name_or_number_error_messages.Should(  ).Contain( number_or_name_settings.max_length_exceeded_error_message );
            return this;
        }


        public Then line_one_exceeds_it_maximum_size_error_is_reported ( ) {
            line_one_error_messages.Should().Contain( line_one_settings.max_length_exceeded_error_message );
            return this;
        }

        public Then line_two_exceeds_it_maximum_size_error_is_reported () {
            line_two_error_messages.Should().Contain( line_two_settings.max_length_exceeded_error_message );
            return this;
        }

        public Then line_three_exceeds_it_maximum_size_error_is_reported () {
            line_three_error_messages.Should().Contain( line_three_settings.max_length_exceeded_error_message );
            return this;
        }

        public Then county_exceeds_it_maximum_size_error_is_reported () {
            county_error_messages.Should().Contain( county_settings.max_length_exceeded_error_message );
            return this;           
        }

        public Then country_exceeds_it_maximum_size_error_is_reported () {
            country_error_messages.Should().Contain( country_settings.max_length_exceeded_error_message );
            return this;           
        }

        public Then postcode_exceeds_it_maximum_size_error_is_reported () {
            postcode_error_messages.Should().Contain( postcode_settings.max_length_exceeded_error_message );
            return this;           
        }

        public Then postcode_contains_invalid_characters_error_is_reported () {
            postcode_error_messages.Should().Contain( postcode_settings.invalid_charaters_error_message );
            return this;           
        }

        public Then postcode_is_madatory_error_is_reported () {
            postcode_error_messages.Should().Contain( postcode_settings.mandatory_field_not_specified_error_message );
            return this;           
        }


        public Then 
                ( IEnumerable<ResponseMessage> the_error_messages ) {

            response_message_helper = new ResponseMessagesHelper( the_error_messages );

        }

        private readonly ResponseMessagesHelper response_message_helper;


        private IEnumerable<ResponseMessage> all_error_messages {
           
            get { return response_message_helper.all_error_messages;}
        }

        private IEnumerable<string> name_or_number_error_messages {

            get { return response_message_helper.name_or_number_error_messages; }
        }

        private IEnumerable<string> line_one_error_messages {
            
            get { return response_message_helper.line_one_error_messages; }
        }

        private IEnumerable<string> line_two_error_messages {
            
            get { return response_message_helper.line_two_error_messages;}
        }

        private IEnumerable<string> line_three_error_messages {
            
            get { return response_message_helper.line_three_error_messages; }
        }

        private IEnumerable<string> county_error_messages {
            
            get { return response_message_helper.county_error_messages; }
        }

        private IEnumerable<string> country_error_messages {
            
            get { return response_message_helper.country_error_messages; }
        }

        private IEnumerable<string> postcode_error_messages {
            
            get { return response_message_helper.postcode_error_messages; }
        }

        private readonly UnitTestNumberOrNameValidatorSettings number_or_name_settings = new UnitTestNumberOrNameValidatorSettings(  );
        private readonly UnitTestAddressLineValidationSettings line_one_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestAddressLineValidationSettings line_two_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestAddressLineValidationSettings line_three_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestAddressLineValidationSettings county_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestAddressLineValidationSettings country_settings = new UnitTestAddressLineValidationSettings(  );
        private readonly UnitTestPostcodeValidatorSettings postcode_settings = new UnitTestPostcodeValidatorSettings(  );

    }
}
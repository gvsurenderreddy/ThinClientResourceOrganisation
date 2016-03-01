using System.Collections.Generic;
using FluentAssertions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique {

    public class Then {

        public Then address_with_same_number_or_name_is_reported ( ) {
            
            name_or_number_error_messages.Should().Contain( setting.number_or_name_error_message );
            return this;
        }

        public Then address_with_same_postcode_is_reported ( ) {
            
            postcode_error_messages.Should().Contain( setting.postcode_error_message );
            return this;
        }

        public Then no_error_are_reported ( ) {
            
            all_error_messages.Should().BeEmpty(  );
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

        private IEnumerable<string> postcode_error_messages {
            
            get { return response_message_helper.postcode_error_messages; }
        }

        private UnitTestsPostalAddressIsUniqueValidatorSettings setting = new UnitTestsPostalAddressIsUniqueValidatorSettings();
    }
}
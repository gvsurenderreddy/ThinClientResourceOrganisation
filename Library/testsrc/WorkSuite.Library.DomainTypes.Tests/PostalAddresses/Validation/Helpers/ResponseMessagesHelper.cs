using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers {

    public class ResponseMessagesHelper {

        public IEnumerable<ResponseMessage> all_error_messages { get; private set; }

        public IEnumerable<string> name_or_number_error_messages {

            get {
                return all_error_messages
                        .Where( m => m.field_name == "number_or_name" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> line_one_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "line_one" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> line_two_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "line_two" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> line_three_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "line_three" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> county_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "county" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> country_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "country" )
                        .Select( m => m.message )
                        ;
            }
        }

        public IEnumerable<string> postcode_error_messages {
            
            get {
                return all_error_messages
                        .Where( m => m.field_name == "postcode" )
                        .Select( m => m.message )
                        ;
            }
        }

        public ResponseMessagesHelper 
                ( IEnumerable<ResponseMessage> the_error_messages ) {

            all_error_messages = the_error_messages;
        }
    }

}
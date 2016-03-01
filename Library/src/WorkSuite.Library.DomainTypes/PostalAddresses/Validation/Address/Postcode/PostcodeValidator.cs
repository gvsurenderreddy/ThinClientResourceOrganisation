using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.Postcode {

    /// <summary>
    ///     Validates the name_or_number field of a postal address
    /// </summary>
    internal class PostcodeValidator {

        /// <summary>
        ///    Checks that a supplied value is a valid postcode and returns
        /// a list of error.  If the value is valid an empty enumeration is returned.
        /// </summary>
        /// <param name="value">
        ///    The value to be validated
        /// </param>
        /// <returns>
        ///     The list of error's if the list is empty then there were not any errors.
        /// </returns>         
        public IEnumerable<ResponseMessage> validate
                                                 ( string value ) {

            const string field_name = "postcode";
            var result = new List<ResponseMessage>();

            // we ignore spaces inside a post code
            var to_validate = value != null ? value.Replace( " ", "" ) : null;

            if ( string.IsNullOrWhiteSpace( to_validate ) ) {

                result.Add( new ResponseMessage{
                    field_name = field_name,
                    message = settings.mandatory_field_not_specified_error_message,
                });
            }

            if ( to_validate != null && to_validate.Length > settings.max_length_of_postcode ) {

                result.Add( new ResponseMessage {
                    field_name = field_name,
                    message = settings.max_length_exceeded_error_message,
                });
            }

            if ( to_validate != null && !to_validate.All( char.IsLetterOrDigit )) {

                result.Add( new ResponseMessage {
                    field_name = field_name,
                    message = settings.invalid_charaters_error_message, 
                });
            }
            return result;
        }

        /// <summary>
        ///     Constructor that requires the validation 
        /// settings to be supplied as an argument.
        /// </summary>
        /// <param name="the_setting">
        ///     The setting that allow the validation to be adjusted 
        /// </param>
        public PostcodeValidator 
                    ( PostcodeValidatorSettings the_setting ) {

            settings = the_setting;
        }

        // settings specified that contain the 
        private readonly PostcodeValidatorSettings settings;

    }

}
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.NumberOrName {

    /// <summary>
    ///     Validates the number_or_name field of a postal address
    /// </summary>
    internal class NumberOrNameValidator {

        /// <summary>
        ///    Validates that a supplied value is a valid name or number and returns
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
            
            const string field_name = "number_or_name";
            var result = new List<ResponseMessage>();


            if ( string.IsNullOrWhiteSpace( value ) ) {

                result.Add( new ResponseMessage{
                    field_name = field_name,
                    message = settings.mandatory_field_not_specified_error_message,
                });
            }

            if ( value != null && value.Length > settings.max_length ) {

                result.Add( new ResponseMessage{
                    field_name = field_name,
                    message = settings.max_length_exceeded_error_message, 
                });
            }
            return result;
        }

        /// <summary>
        ///     Allows the setting that adjust the validation
        /// to be specified.
        /// </summary>
        /// <param name="the_settings">
        /// </param>
        public NumberOrNameValidator
                    ( NumberOrNameValidatorSettings the_settings ) {

            settings = the_settings;
        }

        // setting used to adjust the validation 
        private readonly NumberOrNameValidatorSettings settings;
    }


}
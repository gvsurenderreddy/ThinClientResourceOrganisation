using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine {


    /// <summary>
    ///     Validates the name_or_number field of a postal address
    /// </summary>
    internal class AddressLineValidator {

        /// <summary>
        ///    Checks that a supplied value is a valid address line and returns
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

            var result = new List<ResponseMessage>();

            if ( value != null && value.Length > max_length ) {

                result.Add( new ResponseMessage {
                    field_name = property_name ,
                    message = max_length_exceeded_error_message, 
                });
            }
            return result;
        }

        /// <summary>
        ///     Constructor that requires the validation 
        /// settings to be supplied as an argument.
        /// </summary>
        /// <param name="settings">
        ///     The setting that are used to configure 
        /// </param>
        public AddressLineValidator 
                ( AddressLineValidatorSettings settings ) {
            
            Guard.IsNotNull( settings, "the_settins") ;
            Guard.IsNotNull( settings.setting, "the_settings.setting" );

            property_name  = settings.property_name;

            max_length = settings.setting.max_length;
            max_length_exceeded_error_message = settings.setting.max_length_exceeded_error_message;
        }


        private readonly string property_name;
        private readonly int max_length;
        private readonly string max_length_exceeded_error_message;
    }

}
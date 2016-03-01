using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.Postcode;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address {

    /// <summary>
    ///     Employee address postcode validator settings
    /// </summary>
    public class EmployeeAddressPostcodeValidatorSettings
                    : PostcodeValidatorSettings {

        /// <summary>
        ///     maximum number of characters allowed in a postcode.
        /// </summary>
        public int max_length_of_postcode {

            get { return ValidationConstraints.max_text_field_length_for_post_code; }
        }

        /// <summary>
        ///     error message displayed when postcode exceeds the maximum length
        /// </summary>
        public string max_length_exceeded_error_message {
            
            get { return ValidationMessages.error_00_0014; }
        }

        /// <summary>
        ///     error message displayed when postcode exceeds the maximum length
        /// </summary>
        public string invalid_charaters_error_message {
            
            get { return ValidationMessages.error_00_0028; }
        }

        /// <summary>
        ///     error message displayed when a postcode has not been specified.
        /// </summary>
        public string mandatory_field_not_specified_error_message {
            
            get { return ValidationMessages.error_00_0013; }
        }
    }
}
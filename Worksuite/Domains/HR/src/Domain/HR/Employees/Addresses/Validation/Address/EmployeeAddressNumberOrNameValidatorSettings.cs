using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.NumberOrName;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address {

    /// <summary>
    ///     Employee address number or name validator settings
    /// </summary>
    public class EmployeeAddressNumberOrNameValidatorSettings
                    : NumberOrNameValidatorSettings {

        /// <summary>
        ///     As default address lines are just restricted to our standard
        /// maximum text size.
        /// </summary>
        public virtual int max_length {

            get { return ValidationConstraints.max_text_field_length; }
        }

        /// <summary>
        ///     We use the default maximum field length exceeded error error message.
        /// </summary>
        public virtual string max_length_exceeded_error_message {

            get { return ValidationMessages.error_01_0001; }
        }

        /// <summary>
        ///     Error message displayed when the name or number has not bee
        /// specified. 
        /// </summary>
        public string mandatory_field_not_specified_error_message {
            
            get { return ValidationMessages.error_00_0012; }
        }

    }

}
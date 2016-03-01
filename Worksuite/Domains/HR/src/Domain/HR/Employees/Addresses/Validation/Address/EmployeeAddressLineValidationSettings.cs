using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address {

    /// <summary>
    ///     Defines the default generic address line validation settings such as
    /// the maximum length and message if it is violated etc.
    /// </summary>
    public class EmployeeAddressLineValidationSettings
                    : AddressLineValidationSettings {
        


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

    }
}
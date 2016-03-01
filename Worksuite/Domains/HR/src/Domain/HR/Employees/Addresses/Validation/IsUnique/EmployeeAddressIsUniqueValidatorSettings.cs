using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.IsUnique {

    /// <summary>
    ///     Setting used for the employee address is unique validator.
    /// </summary>
    public class EmployeeAddressIsUniqueValidatorSettings 
                    : PostalAddressIsUniqueValidatorSettings  {

        /// <inheritdoc/>
        public string number_or_name_error_message {
            
            get { return ValidationMessages.error_00_0015; }
        }

        /// <inheritdoc/>
        public string postcode_error_message {
            
            get { return ValidationMessages.error_00_0016; }
        }
    }
}
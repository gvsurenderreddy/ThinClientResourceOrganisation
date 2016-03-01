using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.Address {


    /// <summary>
    ///     Redefines the standard <see cref="PostalAddressValidator"/> so that it 
    /// uses  employee address specific field validators.
    /// </summary>
    /// <inheritdoc/>
    public class EmployeeAddressValidator
                            : PostalAddressValidator {

        /// <summary>
        /// Sets the field validators to be the employee address specific 
        /// validators.
        /// </summary>
        public EmployeeAddressValidator 
                       ( ) 
                : base ( new EmployeeAddressNumberOrNameValidatorSettings()
                       , new EmployeeAddressLineValidationSettings()
                       , new EmployeeAddressLineValidationSettings()
                       , new EmployeeAddressLineValidationSettings()
                       , new EmployeeAddressLineValidationSettings()
                       , new EmployeeAddressLineValidationSettings()
                       , new EmployeeAddressPostcodeValidatorSettings() ) { }
    }
}
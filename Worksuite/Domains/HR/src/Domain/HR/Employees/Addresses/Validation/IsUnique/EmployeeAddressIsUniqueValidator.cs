using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Validation.IsUnique {

    /// <summary>
    ///     validator that checks that an employee address would
    /// be unique within a collection.
    /// </summary>    
    public class EmployeeAddressIsUniqueValidator 
                    : PostalAddressIsUniqueValidator {

        public EmployeeAddressIsUniqueValidator ( ) 
                : base( new EmployeeAddressIsUniqueValidatorSettings(  ) ) {}

    }

}
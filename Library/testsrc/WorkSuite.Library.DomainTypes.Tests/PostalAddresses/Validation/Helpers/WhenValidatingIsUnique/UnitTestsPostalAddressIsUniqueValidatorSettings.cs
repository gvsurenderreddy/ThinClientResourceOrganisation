using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique {

    public class UnitTestsPostalAddressIsUniqueValidatorSettings
                    : PostalAddressIsUniqueValidatorSettings {

        public string number_or_name_error_message {

            get { return "This house number or name and its matching Post code cannot be used because it has already been created. Please enter a different house number."; }
        }
        public string postcode_error_message {
            
            get { return "This house number or name and its matching Post code cannot be used because it has already been created. Please enter a different postcode."; }
        }

    }

}
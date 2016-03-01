using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.Postcode;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    public class UnitTestPostcodeValidatorSettings
                    : PostcodeValidatorSettings {

        public int max_length_of_postcode { get { return 8; }}
        public string max_length_exceeded_error_message { get { return "Maximum fields size has been exceeded"; } }
        public string invalid_charaters_error_message { get { return "Postcode contains invalid characters"; } }
        public string mandatory_field_not_specified_error_message { get { return "Name or number is mandatory"; } }

    }
}
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.NumberOrName;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    public class UnitTestNumberOrNameValidatorSettings
                    : NumberOrNameValidatorSettings {

        public int max_length { get { return 100; } }
        public string max_length_exceeded_error_message { get { return "Maximum fields size has been exceeded"; } }
        public string mandatory_field_not_specified_error_message { get { return "Name or number is mandatory"; } }

    }

}
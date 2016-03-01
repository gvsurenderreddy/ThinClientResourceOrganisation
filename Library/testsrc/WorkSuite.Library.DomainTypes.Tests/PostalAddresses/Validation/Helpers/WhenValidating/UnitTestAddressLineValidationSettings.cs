using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    public class UnitTestAddressLineValidationSettings
                            : AddressLineValidationSettings {

        public virtual int max_length { get { return 100; } }
        public virtual string max_length_exceeded_error_message { get { return "Maximum fields size has been exceeded"; } }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating {

    public class PostalAddressValidatorSpecification {

        [TestInitialize]
        public void before_each_test ( ) {
            given = new Given();

        }

        internal Given given { get; private set;}
    }

}
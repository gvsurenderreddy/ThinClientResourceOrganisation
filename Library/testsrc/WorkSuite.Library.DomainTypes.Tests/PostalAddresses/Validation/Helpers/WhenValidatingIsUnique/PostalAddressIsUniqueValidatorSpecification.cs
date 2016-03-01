using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidatingIsUnique {

    public class PostalAddressIsUniqueValidatorSpecification {

        [TestInitialize]
        public void before_each_test ( ) {
            given = new Given();

        }

        internal Given given { get; private set;}
    }

}
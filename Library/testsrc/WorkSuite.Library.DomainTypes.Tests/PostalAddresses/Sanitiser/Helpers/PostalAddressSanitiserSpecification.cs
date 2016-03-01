using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers {

    public class PostalAddressSanitiserSpecification {

        [TestInitialize] 
        public void before_each_test () {
            given = new Given();
        }

        internal Given given { get; private set; }

    }

}
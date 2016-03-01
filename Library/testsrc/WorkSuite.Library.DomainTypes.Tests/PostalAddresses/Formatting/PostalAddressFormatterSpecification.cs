using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Formatting
{
    public class PostalAddressFormatterSpecification
    {
        [TestInitialize]
        public void before_each_test()
        {
            given = new Given();
        }

        internal Given given { get; private set; }
    }
}
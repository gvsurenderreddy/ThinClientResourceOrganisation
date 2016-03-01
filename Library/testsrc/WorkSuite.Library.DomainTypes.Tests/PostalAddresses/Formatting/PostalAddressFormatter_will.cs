using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Sanitiser.Helpers;
using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Validation.Helpers.WhenValidating;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Formatting
{
    [TestClass]
    public class PostalAddressFormatter_will
                        : PostalAddressFormatterSpecification
    {
        [TestMethod]
        public void returns_an_ienumerable_string_for_a_valid_address()
        {
            this
                .given
                .a_valid_postal_address()

                .when()
                .the_address_is_formatted()

                .then()
                .a_list_is_returned()
                ;
        }
    }
}
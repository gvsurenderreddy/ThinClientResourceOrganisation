using WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Formatting
{
    internal class Given
                    : GivenAPostalAddress<When>
    {

        public override When when()
        {

            return new When(postal_address);
        }
    }
}
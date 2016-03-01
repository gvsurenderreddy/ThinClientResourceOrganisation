using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Formatting;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Formatting
{
    public class When
    {

        public When the_address_is_formatted()
        {

            var formatter = new PostalAddressFormatter();

            formatted_address = formatter.format(address);

            return this;
        }

        public Then then()
        {
            return new Then(formatted_address);
        }

        public When
                (IPostalAddress the_address)
        {

            address = Guard.IsNotNull(the_address, "the_address");
        }

        private IEnumerable<string> formatted_address;
        private readonly IPostalAddress address;
    }
}

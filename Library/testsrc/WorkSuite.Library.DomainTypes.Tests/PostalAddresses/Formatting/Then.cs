using System.Collections.Generic;
using FluentAssertions;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.PostalAddresses.Formatting
{
    public class Then
    {
        public Then a_list_is_returned()
        {
            formatted_address.Should().NotBeEmpty();

            return this;
        }

        public Then
                (IEnumerable<string> the_formatted_address)
        {

            formatted_address = the_formatted_address;

        }

        private IEnumerable<string> formatted_address;
    }
}

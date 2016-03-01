using System.Collections.Generic;
using System.Linq;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Formatting
{
    /// <summary>
    ///     Formats a postal address 
    /// </summary>
    public class PostalAddressFormatter
    {
        public IEnumerable<string> format(IPostalAddress address )
        {
            return new List<string>
            {
                address.number_or_name,
                address.line_one,
                address.line_two,
                address.line_three,
                address.county,
                address.country,
                address.postcode
            }
                // remove address lines that were not specified in the address
                .Where(l => l != null);
        }
    }
}
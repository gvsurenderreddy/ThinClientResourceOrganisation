using System.Collections.Generic;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique {

    /// <summary>
    ///     Contains the parameters that are needed
    /// </summary>
    public class PostalAddressIsUniqueRequest {

        /// <summary>
        ///     address to be checked
        /// </summary>
        public IPostalAddress address { get; set; }

        /// <summary>
        ///     collection to check
        /// </summary>
        public IEnumerable<IPostalAddress> addresses { get; set; }
    }
}
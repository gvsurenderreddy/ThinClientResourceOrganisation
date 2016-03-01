namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses {

    /// <summary>
    ///     Postal address
    /// </summary>
    public interface IPostalAddress {

        /// <summary>
        ///     the name or number assigned to the postal address
        /// </summary>
        string number_or_name { get; set; }

        /// <summary>
        ///     First line of the postal address.
        /// </summary>
        string line_one { get; set; }

        /// <summary>
        ///     Second line of the postal address.
        /// </summary>
        string line_two { get; set; }

        /// <summary>
        ///     Third line of the postal address.
        /// </summary>
        string line_three { get; set; }

        /// <summary>
        ///     County that the postal address resides in.
        /// </summary>
        string county { get; set; }

        /// <summary>
        ///     Country that the postal address resides in.
        /// </summary>
        string country { get; set; }

        /// <summary>
        ///     Post codes assigned to the postal address.
        /// </summary>
        string postcode { get; set; }
    }

}
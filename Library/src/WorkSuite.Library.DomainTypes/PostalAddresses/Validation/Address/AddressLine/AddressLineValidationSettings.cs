namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine {

    /// <summary>
    ///     Generic settings for an address line validation
    /// </summary>
    public interface AddressLineValidationSettings {

        /// <summary>
        ///     The maximum size that an address line is allowed to be.
        /// </summary>
        int max_length { get; }

        /// <summary>
        ///     Error message reported if the maximum size has been exceeded.
        /// </summary>
        string max_length_exceeded_error_message { get; }
         

    }

}
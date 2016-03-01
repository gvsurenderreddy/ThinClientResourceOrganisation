namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.NumberOrName {
    /// <summary>
    ///     Setting use by the address line validator
    /// </summary>
    public interface NumberOrNameValidatorSettings {

        /// <summary>
        ///     The maximum size that an address line is allowed to be.
        /// </summary>
        int max_length { get; }

        /// <summary>
        ///     Error message reported if the maximum size has been exceeded.
        /// </summary>
        string max_length_exceeded_error_message { get; }

        /// <summary>
        ///     Error message reported if the field has not been specified, 
        /// name_or_number is mandatory.
        /// </summary>
        string mandatory_field_not_specified_error_message { get; }
    }
}
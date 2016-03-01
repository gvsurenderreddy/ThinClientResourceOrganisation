namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.Postcode {

    /// <summary>
    ///     Setting use by the postcode validator
    /// </summary>
    public interface PostcodeValidatorSettings {

        /// <summary>
        ///     The maximum size that the post code is allowed, note interior spaces 
        /// are stripped out before this is validated e.g. if the max size is 3 then 
        /// "xx x" would still be considered valid.
        /// </summary>
        int max_length_of_postcode { get; }

        /// <summary>
        ///     Error message reported if the maximum size has been exceeded.
        /// </summary>
        string max_length_exceeded_error_message { get; }

        /// <summary>
        ///     Error message reported if any invalid characters are found. 
        /// </summary>
        string invalid_charaters_error_message { get; }

        /// <summary>
        ///     Error message reported if the field has not been specified, 
        /// postcode is mandatory.
        /// </summary>
        string mandatory_field_not_specified_error_message { get; }

    }
}
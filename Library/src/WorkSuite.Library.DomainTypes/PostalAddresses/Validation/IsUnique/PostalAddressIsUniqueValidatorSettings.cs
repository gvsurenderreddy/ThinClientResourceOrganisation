namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique {

    /// <summary>
    ///     Setting used to tailor the postal address is unique setting validation
    /// </summary>
    public interface PostalAddressIsUniqueValidatorSettings {

        /// <summary>
        ///     Error message to be reported for the name or number field if the validation fails
        /// </summary>
        string number_or_name_error_message { get; }

        /// <summary>
        ///     Error message to be reported for the postcode field if the validation fails
        /// </summary>
        string postcode_error_message { get; }
    }

}
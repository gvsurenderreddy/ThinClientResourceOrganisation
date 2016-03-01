namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine {

    /// <summary>
    ///     Setting use by the address line validator
    /// </summary>
    internal class AddressLineValidatorSettings {

        /// <summary>
        ///     Name of the specific address line being validated. The 
        /// <see cref="AddressLineValidator"/> is a generic address line validator 
        /// which is used for address lines that do not have domain specific
        /// validation rules so we need to identify which field it is being
        /// used against.
        /// </summary>
        public string property_name { get; set; }

        /// <summary>
        ///     The settings that used to configure the validator
        /// </summary>
        public AddressLineValidationSettings setting { get; set; }
    }
}
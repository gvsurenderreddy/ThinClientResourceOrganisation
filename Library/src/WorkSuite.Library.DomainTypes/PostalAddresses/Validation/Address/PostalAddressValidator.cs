using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.AddressLine;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.NumberOrName;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address.Postcode;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.Address {

    /// <summary>
    ///     Validates that the fields within a postal address are valid
    /// </summary>
    public class PostalAddressValidator {
        
        /// <summary>
        ///     Validates the address supplied as an argument and returns
        /// a list of the errors.  If the list is empty then there were 
        /// no errors.     
        /// </summary>
        /// <param name="the_address">
        ///     Postal address that is to be validated
        /// </param>
        /// <returns>
        ///     The list of error's if the list is empty then there were not any errors.
        /// </returns>
        public virtual IEnumerable<ResponseMessage> validate    
                                                        ( IPostalAddress the_address ) {

            return this
                    .set_address_to_validate( the_address )
                    .validate_name_or_number()
                    .validate_line_one()
                    .validate_line_two()
                    .validate_line_three()
                    .validate_county()
                    .validate_country()
                    .validate_postcode()
                    .errors
                    ;
        }


        /// <summary>
        ///     Constructor accepts the field validators
        /// </summary>
        public PostalAddressValidator 
                ( NumberOrNameValidatorSettings number_or_name_settings
                , AddressLineValidationSettings line_one_settings 
                , AddressLineValidationSettings line_two_settings 
                , AddressLineValidationSettings line_three_settings 
                , AddressLineValidationSettings county_settings 
                , AddressLineValidationSettings country_settings 
                , PostcodeValidatorSettings postcode_settings ) {
            
            Guard.IsNotNull( number_or_name_settings, "number_or_name_settings" );
            Guard.IsNotNull( line_one_settings, "line_one_settings" );
            Guard.IsNotNull( line_two_settings, "line_two_settings" );
            Guard.IsNotNull( line_three_settings, "line_three_settings" );
            Guard.IsNotNull( county_settings, "county_settings" );
            Guard.IsNotNull( country_settings, "country_settings" );
            Guard.IsNotNull( postcode_settings, "postcode_settings" );

            number_or_name_validator = new NumberOrNameValidator( number_or_name_settings );
            line_one_validator = new AddressLineValidator( new AddressLineValidatorSettings { property_name = "line_one", setting = line_one_settings });
            line_two_validator = new AddressLineValidator( new AddressLineValidatorSettings { property_name = "line_two", setting = line_two_settings });
            line_three_validator = new AddressLineValidator( new AddressLineValidatorSettings { property_name = "line_three", setting = line_three_settings });
            county_validator = new AddressLineValidator( new AddressLineValidatorSettings { property_name = "county", setting = county_settings });
            country_validator = new AddressLineValidator( new AddressLineValidatorSettings { property_name = "country", setting = country_settings });
            postcode_validator = new PostcodeValidator( postcode_settings );
        }


        private PostalAddressValidator set_address_to_validate
                                            ( IPostalAddress the_address ) {

            address = Guard.IsNotNull( the_address, "the_address" );
            clear_all_errors();
            return this;
        }

        private PostalAddressValidator validate_name_or_number () {
            Guard.IsNotNull( address, "address" );

            add_errors( number_or_name_validator.validate( address.number_or_name ));
            return this;
        }

        private PostalAddressValidator validate_line_one () {
            Guard.IsNotNull( address, "address" );

            add_errors( line_one_validator.validate( address.line_one ));
            return this;
        }

        private PostalAddressValidator validate_line_two () {
            Guard.IsNotNull( address, "address" );

            add_errors( line_two_validator.validate( address.line_two ));
            return this;
        }

        private PostalAddressValidator validate_line_three () {
            Guard.IsNotNull( address, "address" );

            add_errors( line_three_validator.validate( address.line_three ));
            return this;
        }

        private PostalAddressValidator validate_county () {
            Guard.IsNotNull( address, "address" );

            add_errors( county_validator.validate( address.county ));
            return this;
        }

        private PostalAddressValidator validate_country () {
            Guard.IsNotNull( address, "address" );

            add_errors( country_validator.validate( address.country ));
            return this;
        }

        private PostalAddressValidator validate_postcode () {
            Guard.IsNotNull( address, "address" );

            add_errors( postcode_validator.validate( address.postcode ));
            return this;
        }


        private IPostalAddress address;
        
        private readonly NumberOrNameValidator number_or_name_validator;
        private readonly AddressLineValidator line_one_validator; 
        private readonly AddressLineValidator line_two_validator; 
        private readonly AddressLineValidator line_three_validator; 
        private readonly AddressLineValidator county_validator; 
        private readonly AddressLineValidator country_validator;
        private readonly PostcodeValidator postcode_validator;

        // clears any existing response errors
        private void clear_all_errors () {
            // just create a new list so that if anybody is holding a reference
            // to the current errors list (they should not be but you never know) 
            // we do not wipe that out. 
            errors = new List<ResponseMessage>();
        }
        private void add_errors
                        ( IEnumerable<ResponseMessage> the_errors ) {
            
            errors.AddRange( the_errors );
        }
        private List<ResponseMessage> errors = new List<ResponseMessage>();
    }
}
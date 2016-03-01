using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Validation.IsUnique {

    /// <summary>
    ///     Validates that the address is unique
    /// </summary>
    public class PostalAddressIsUniqueValidator {


        /// <summary>
        ///     Check that the address is not is the collection
        /// </summary>
        /// <param name="validation_request">
        ///     Validation request that contains the address to look for 
        /// and the collection of addresses to look in.
        /// </param>
        /// <returns>
        ///     An empty collection if the address is not in the collection, otherwise it returns a 
        /// collection that contains the errors.
        /// </returns>
        public IEnumerable<ResponseMessage> validate 
                                                ( PostalAddressIsUniqueRequest validation_request ) {

            Guard.IsNotNull( validation_request, "validation_request" );
            Guard.IsNotNull( validation_request.address, "validation_request.address" );
            Guard.IsNotNull( validation_request.addresses, "validation_request.addresses" );

            // get the address identity 
            var new_address_key = get_identity( validation_request.address );

            // an employee can not already have an address with the same number_or_name and postcode
            var existing_address_keys = validation_request
                                            .addresses
                                            .Select( get_identity );


            var duplicate_addresses = existing_address_keys
                                        .Where( a => string.Compare( a.number_or_name, new_address_key.number_or_name, StringComparison.OrdinalIgnoreCase ) == 0 )
                                        .Where( a => string.Compare( a.postcode, new_address_key.postcode, StringComparison.OrdinalIgnoreCase ) == 0 )
                                        ;

            if (  duplicate_addresses.Any() ) {

                return new List<ResponseMessage> {
                    // number or name error
                    new ResponseMessage {
                        field_name = "number_or_name",
                        message = settings.number_or_name_error_message,
                    },

                    // postcode error
                    new ResponseMessage {
                        field_name = "postcode",
                        message = settings.postcode_error_message,
                    },
                };
            }
            return new List<ResponseMessage>();
        }

        /// <summary>
        ///     Accepts the setting that are used to configure the validation
        /// </summary>
        /// <param name="the_settings">
        ///     The setting used to tailor the validation.
        /// </param>
        public PostalAddressIsUniqueValidator 
                ( PostalAddressIsUniqueValidatorSettings the_settings ) {
            
            settings = Guard.IsNotNull( the_settings, "the_settings" );
        }

        private PostalAddressIdentity get_identity
                                        ( IPostalAddress address ) {

            return new PostalAddressIdentity {
                number_or_name = address.number_or_name ?? string.Empty,
                postcode = address.postcode != null ? address.postcode.ToUpper().Replace( " ", "") : string.Empty,
            };            
        }

        private readonly PostalAddressIsUniqueValidatorSettings settings;
    }

}
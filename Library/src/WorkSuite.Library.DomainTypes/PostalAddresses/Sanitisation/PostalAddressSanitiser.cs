using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Sanitisation {

    /// <summary>
    ///     Sanitizes a postal address 
    /// </summary>
    public class PostalAddressSanitiser {

        /// <summary>
        ///     performs the sanitisation on the postal address
        /// </summary>
        /// <param name="address">
        ///     the address that is to be sanitised.
        /// </param>
        public void sanitise 
                        ( IPostalAddress address ) {
            
            address.number_or_name = address.number_or_name.normalise_for_persistence( );
            address.line_one = address.line_one.normalise_for_persistence( );
            address.line_two = address.line_two.normalise_for_persistence( );
            address.line_three = address.line_three.normalise_for_persistence( );
            address.county = address.county.normalise_for_persistence( );
            address.country = address.country.normalise_for_persistence( );
            address.postcode = address.postcode.normalise_for_persistence( ).convert_to_uppercase(  );
        }       
    }
}
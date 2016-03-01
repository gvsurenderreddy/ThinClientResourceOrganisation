using System.Linq;

namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation {

    /// <summary>
    ///     Contains the primitive string sanitisation methods
    /// </summary>
    public static class StringSanitiser {
        
        
        /// <summary>
        ///     strips leading and trailing whitespace and converts empty strings to null
        /// </summary>
        /// <param name="value">
        ///     the string to be normalised.
        /// </param>
        /// <returns>
        ///     a normalised version of the string
        /// </returns>
        public static string normalise_for_persistence
                                ( this string value ) {

            var trimmed_value = value.trim_whitespace();
            
            return null_values.Any( nv => nv == trimmed_value ) ? null : trimmed_value;
        }
        
        private readonly static string[] null_values = new [] { "", null };


        /// <summary>
        ///     strips leading and trailing whitespace and converts empty strings to null
        /// </summary>
        /// <param name="value">
        ///     the string to be normalised.
        /// </param>
        /// <returns>
        ///     a normalised version of the string
        /// </returns>
        public static string normalise_for_presentation
                                ( this string value ) {

            return value.trim_whitespace() ?? string.Empty;
        }
        

        /// <summary>
        ///     trims whitespace, if a null is passed it just returns the 
        /// null as that be definition can not have any leading or trailing 
        /// spaces.
        /// </summary>
        /// <param name="value">
        ///     The value to be trimmed
        /// </param>
        /// <returns>
        ///     a version of the value with leading and trailing spaces removed 
        /// or null if the argument was null
        /// </returns>
        public static string trim_whitespace
                                ( this string value ) {
            
            return value != null ? value.Trim() : null;
        }


        /// <summary>
        ///     converts a string to uppercase or returns null if the string
        /// is null.
        /// </summary>
        /// <param name="value">
        ///     the string to be converted
        /// </param>
        /// <returns>
        ///     the converted string
        /// </returns>
        public static string convert_to_uppercase
                                ( this string value ) {

            return ( value == null ) ? null : value.ToUpper();
        }
    }
}
using System.Collections.Generic;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral {

    /// <summary>
    ///     Simple lookup that has a default value.  When a 
    /// key is looked up that does not exist the default value is 
    /// returned
    /// </summary>
    /// <typeparam name="Key">
    ///     Type of the key that will be used for looking the value up
    /// </typeparam>
    /// <typeparam name="Value">
    ///     Type of the value returned by a lookup
    /// </typeparam>
    public class DefaultedLookup<Key,Value> {

        /// <summary>
        ///     Looks up the value for the specified key 
        /// </summary>
        /// <param name="key">
        ///     Key that you want the value for
        /// </param>
        /// <returns>
        ///     Value for the specified key or the default value
        /// </returns>
        public Value this[ Key key ] {
            get {
                
                if ( lookup_register.ContainsKey( key ) ) {
                    return lookup_register[key ];
                }
                return default_value;
            }
        }

        /// <summary>
        ///     Registers a key value pair
        /// </summary>
        /// <param name="key">
        ///     Key that identifies the value
        /// </param>
        /// <param name="value">
        ///     Value returned when the key is looked up
        /// </param>
        public DefaultedLookup<Key,Value> register 
                    ( Key key
                    , Value value ) {
            
            lookup_register[ key ] = value;
            return this;
        }

        /// <summary>
        ///     Set the default value from the argument
        /// </summary>
        /// <param name="the_default_value">
        ///     Value that you want the default value to be.
        /// </param>
        public DefaultedLookup 
                ( Value the_default_value ) {
            
            default_value = the_default_value;
        }

        // default value returned when a key does not exist.
        private readonly Value default_value;

        // dictionary used to store the registered lookups.
        private readonly Dictionary<Key,Value> lookup_register = new Dictionary<Key,Value>();
    }
}
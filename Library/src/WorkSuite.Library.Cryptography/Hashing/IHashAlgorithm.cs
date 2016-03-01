namespace WTS.WorkSuite.Library.Cryptography.Hashing {

    /// <summary>
    ///     Standard hashing interface that provides  
    /// </summary>
    public interface IHashAlgorithm {

        /// <summary>
        ///     Creates a hash from the message.
        /// </summary>
        /// <param name="message">
        ///     String that will be hashed.
        /// </param>
        /// <returns>
        ///     Hash generated from the string
        /// </returns>
        string hash( string  message );


        /// <summary>
        ///     Verifies whether the message is the same as the message that 
        /// was used to generate the hash.
        /// </summary>
        /// <param name="message">
        ///     A message that you want to verify. 
        /// </param>
        /// <param name="hash">
        ///     A hash that you want to verify the message against.
        /// </param>
        /// <returns>
        ///     True if the hash was generated from the same message.
        /// </returns>
        bool verify ( string message, string hash );


    }

}
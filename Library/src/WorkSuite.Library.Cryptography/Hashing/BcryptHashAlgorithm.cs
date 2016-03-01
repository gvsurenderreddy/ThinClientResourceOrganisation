namespace WTS.WorkSuite.Library.Cryptography.Hashing {

    /// <summary>
    ///     Bcrypt implementation of the IHashAlgorithm
    /// </summary>
    public class BcryptHashAlgorithm : IHashAlgorithm {

        /// <inheritdoc/>
        public string hash ( string message ) {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            return BCrypt.Net.BCrypt.HashPassword( message, salt );
        }

        /// <inheritdoc/>
        public bool verify ( string message, string hash ) {

            return BCrypt.Net.BCrypt.Verify( message, hash );
        }

    }

}
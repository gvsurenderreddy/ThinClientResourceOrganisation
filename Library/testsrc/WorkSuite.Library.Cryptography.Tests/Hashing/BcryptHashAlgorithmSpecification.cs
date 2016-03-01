using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.Cryptography.Hashing;

namespace WTS.WorkSuite.Library.Cryptography.Tests.Hashing {

    [TestClass]
    public class BcryptHashAlgorithmSpecification : IHashAlgorithmSpecification<BcryptHashAlgorithm> {

        protected override BcryptHashAlgorithm create_hash_algorithm ( ) {
            return new BcryptHashAlgorithm(  );
        }

    }

}
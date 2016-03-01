using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.Cryptography.Hashing;

namespace WTS.WorkSuite.Library.Cryptography.Tests.Hashing {

    [TestClass]
    public abstract class IHashAlgorithmSpecification<A> 
        where A : IHashAlgorithm {


        [TestMethod]
        public void verify_returns_true_if_the_hash_was_generated_from_the_message ( ) {
            var hash_algorithm = create_hash_algorithm();
            var message = "abcdefghijklmnopqrstuvwxyz";
            var hash = hash_algorithm.hash( message );

            hash_algorithm.verify( message, hash ).Should().BeTrue(  );
        }


        [TestMethod]
        public void verify_returns_false_if_the_hash_was_not_generated_from_the_message ( ) {            
            var hash_algorithm = create_hash_algorithm();
            var message = "abcdefghijklmnopqrstuvwxyz";
            var alternative = "abcdefghijklmnopqrstuvwxya";
            var hash = hash_algorithm.hash( message );

            hash_algorithm.verify( alternative, hash ).Should().BeFalse(  );
        }


        protected abstract A create_hash_algorithm();

    }

}
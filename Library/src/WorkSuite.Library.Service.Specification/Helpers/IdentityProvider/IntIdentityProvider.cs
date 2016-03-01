using System.Threading;
using WorkSuite.Library.Persistence;

namespace WorkSuite.Library.Service.Specification.Helpers.IdentityProvider {

    public class IntIdentityProvider<E> : IdentityProvider<E,int>
        where E : BaseEntity<int> {

        public override int next ( ) {
            // Just in case we have a test runner that 
            // executes test in parallel.  This would be kind of
            // hard to track down and be annoying as it would 
            // be a test infrastructure error. 
            return Interlocked.Increment( ref sequence );
        }

        private static int sequence=1;
    }

}
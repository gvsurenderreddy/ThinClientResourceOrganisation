using System;
using Ninject;
using Ninject.Activation;
using Ninject.Activation.Caching;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WTS.WorkSuite.Allocation.Services.Helpers.SpecificationTemplates {


    /// <summary>
    ///     Test bootstrapper, this is used by the sepcification to set up 
    /// a test run.  It should not containt test specific items (these should be 
    /// done in a test fixture), it is intended that it will be used to 
    /// </summary>
    public abstract class TestBootstrapper {

        // set up ready for a test run.
        public void setup 
                        ( Func<IContext, object> scope) {

            lock (guard) {

                if (!domain_has_been_configured) {
                    initialise_for_test_run( DependencyResolver.kernel, scope );

                    domain_has_been_configured = true;
                }             
            }
        }


        // cleans up after a test run
        public void teardown
                        ( object scope ) {

            DependencyResolver.kernel.Components.Get<ICache>(  ).Clear( scope );
        }

        /// <summary>
        ///     Configure any of the test infrastructure than needs to be applied
        /// just once per test run.
        /// </summary>
        protected abstract void initialise_for_test_run 
                                    ( IKernel kernel
                                    , Func<IContext, object> scope );

                
        private static bool domain_has_been_configured;
        private static object guard = new object(); 
    }
}
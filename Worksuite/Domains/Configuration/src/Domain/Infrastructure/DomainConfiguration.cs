using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Infrastructure {

    /// <summary>
    ///     Configures an Ninject Kernel with the domain assemblies implementation
    /// of the service layer interfaces.
    /// </summary>
    public class DomainConfiguration 
                    : IDependencyConfiguration  {

        /// <summary>
        ///     Load all the configurations in this assembly
        /// </summary>
        /// <param name="kernel">
        ///     The kernel to be configured
        /// </param>
        /// <param name="scope">
        ///     The scope to use for any scope sensitive configurations.
        /// </param>
        public void configure 
                        ( IKernel kernel
                        , Func<IContext, object> scope ) {

            var configurator = new AssemblyConfiguration( GetType(  ).Assembly );

            configurator.configure( kernel, scope );
        }


        public static void apply_to
                            ( IKernel kernel
                            , Func<IContext, object> scope ) {

            var domain_configuration = new DomainConfiguration();

            domain_configuration.configure( kernel, scope );
        }
    }
}
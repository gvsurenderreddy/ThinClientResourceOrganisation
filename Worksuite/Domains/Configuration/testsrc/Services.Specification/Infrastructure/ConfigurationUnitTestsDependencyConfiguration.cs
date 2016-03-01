using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WorkSuite.Configuration.Service.Infrastructure {

    /// <summary>
    ///     Applies a fake configuration system persistent layer depenendy configuration
    /// to an Ninject kernel.
    /// </summary>
    public class ConfigurationUnitTestsDependencyConfiguration {

        /// <summary>
        ///     Load all the depenendcy configurations in this assembly
        /// </summary>
        /// <param name="kernel">
        ///     The kernel to be configured
        /// </param>
        /// <param name="scope">
        ///     The scope to use for any scope sensitive configurations.
        /// </param>
        public static void apply 
                            ( IKernel kernel
                            , Func<IContext, object> scope ) {
            
            var configurator = new AssemblyConfiguration( typeof(ConfigurationUnitTestsDependencyConfiguration).Assembly );

            configurator.configure( kernel, scope );

            kernel
                .Rebind< IUnitOfWork
                       , FakeUnitOfWork>()
                .To<FakeUnitOfWork>()
                .InScope( scope )
                ;
            
         
        }        
    }

}
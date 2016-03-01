using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration {

    public class LibraryConfiguration : IDependencyConfiguration  {

        /// <summary>
        ///     Load all the configurations in this assembly
        /// </summary>
        /// <param name="kernel">
        ///     The kernel to be configured
        /// </param>
        /// <param name="scope">
        ///     The scope to use for any scope sensitive configurations.
        /// </param>
        public void configure ( IKernel kernel, Func<IContext, object> scope ) {
            var configurator = new WTS.WorkSuite.Library.Ninject.Configuration.AssemblyConfiguration( GetType(  ).Assembly );

            configurator.configure( kernel, scope );
        }

    }

}
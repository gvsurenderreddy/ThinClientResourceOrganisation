using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration;
using WTS.WorkSuite.Services.Integration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Infrastructure.DependencyConfiguration {

    public class ThinClientConfiguration : IDependencyConfiguration  {

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
            register_domain_configurations( kernel, scope );
            register_client_configurations( kernel, scope );
        }

        private void register_domain_configurations ( IKernel kernel, Func<IContext, object> scope ) {

            // configure withe the standard domain
            var services_dependencies_builder = new WorkSuiteServicesDependenciesBuilder();

            services_dependencies_builder
                .include_Configuration_domain()
                .apply( kernel, scope );
        }

        private void register_client_configurations  ( IKernel kernel, Func<IContext, object> scope ) {

            var library_configuration = new LibraryConfiguration();
            library_configuration.configure( kernel, scope );

            var route_configuration = new RouteConfiguration();
            route_configuration.configure( kernel, scope );
        }
    }
}
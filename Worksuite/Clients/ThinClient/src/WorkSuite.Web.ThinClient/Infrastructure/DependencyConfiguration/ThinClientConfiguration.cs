using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Persistence.EF.Infrastructure;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration;
using WTS.WorkSuite.Services.Integration;
using WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.DependencyConfiguration;
using WTS.WorkSuite.Web.ThinClient.Infrastructure.Content;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.DependencyConfiguration {

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
                .include_HR_domain()
                .include_PlannedSupply_domain()
                .include_SupplyShortage_domain()
                .include_ThinClientQuery_domain()
                .apply( kernel, scope );
        }

        private void register_client_configurations  ( IKernel kernel, Func<IContext, object> scope ) {

            var library_configuration = new LibraryConfiguration();
            library_configuration.configure( kernel, scope );

            var route_configuration = new RouteConfiguration();
            route_configuration.configure( kernel, scope );

            var white_space_time_allocation_palette_configuration = new WhiteSpaceTimeAllocationPaletteConfiguration();
            white_space_time_allocation_palette_configuration.configure(kernel, scope);

            var shift_time_allocation_palette_configuration = new ShiftTimeAllocationPaletteConfiguration();
            shift_time_allocation_palette_configuration.configure(kernel, scope);

            var content_dependency_configuration = new ContentDependencyConfiguration();
            content_dependency_configuration.configure(kernel, scope);

            var field_set_validation_response_configuration = new FieldSetValidationResponseConfiguration();
            field_set_validation_response_configuration.configure(kernel, scope);
        }

        private static readonly PersistenceEFConfiguration persistence_configuration = new PersistenceEFConfiguration();

    }

}
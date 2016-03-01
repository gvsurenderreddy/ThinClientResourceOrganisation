using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.Allocation;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.HR;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.PlannedSupply;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.SupplyShortage;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.ThinClientQueryDomainConfiguration;

namespace WTS.WorkSuite.Services.Integration {

    /// <summary>
    ///     Builder that allows a client to specify what domains they need access 
    /// to and then apply the bingdings for thoes domains to an Ninject kernel
    /// </summary>
    public class WorkSuiteServicesDependenciesBuilder {

        public WorkSuiteServicesDependenciesBuilder include_Allocation_domain () {
            
            domains_to_configure.add_configuration<AllocationDomainConfiguration>();
            return this;
        }

        public WorkSuiteServicesDependenciesBuilder include_ThinClientQuery_domain()
        {

            domains_to_configure.add_configuration<ThinClientQueryDomainConfiguration>();
            return this;
        }

        public WorkSuiteServicesDependenciesBuilder include_HR_domain () {
            
            domains_to_configure.add_configuration<HRDomainConfiguration>();
            return this;
        }

        public WorkSuiteServicesDependenciesBuilder include_PlannedSupply_domain () {
                        
            domains_to_configure.add_configuration<PlannedSupplyDomainConfiguration>();
            return this;
        }

        public WorkSuiteServicesDependenciesBuilder include_SupplyShortage_domain()
        {

            domains_to_configure.add_configuration<SupplyShortageDomainConfiguration>();
            return this;
        }

        public void apply
                        ( IKernel kernel 
                        , Func<IContext,object> scope ) {
            
            var processed_domains = new HashSet<Type>();

            // load the queue with all domains that need to be set up in the kernel
            var queue = new Queue<DomainConfiguration>();

            domains_to_configure
                .domains
                .Do( queue.Enqueue )
                ;

            // Perfrom a breadth first search of the configuration graph.  Note we 
            // identify whether the a vertex has been processed by a type check rather 
            // than an instance check because different configuration will have different 
            // instances of the domain but a domain configuration will allways come from 
            // the same type.
            while (queue.Count > 0) {
                var current_domain = queue.Dequeue();

                if ( !processed_domains.Contains( current_domain.GetType() )) {
                    processed_domains.Add( current_domain.GetType() );

                    current_domain.domain_bindings.configure( kernel, scope );

                    current_domain
                        .service_need_by_the_domain
                        .Union( current_domain.services_that_the_domain_listens_for_events_from )
                        .Do( dc => {

                            if (!processed_domains.Contains( dc.GetType() )) {
                                queue.Enqueue( dc );
                            }
                        });
                }
            }
        }


        private readonly ConfiguirationRegister domains_to_configure = new ConfiguirationRegister();

        private class ConfiguirationRegister {

            public IEnumerable<DomainConfiguration> domains {
                get { return configurations;  }
            } 
                        
            public void add_configuration<T>( ) 
                            where T : DomainConfiguration, new() {

                // create a collections that includes the domain that the
                // user wants to include and all the domains the listen
                // for events from that domain.
                var configuration_type = typeof(T);
                var requested_configuration = ( new[] { new T() });
                var listeners = domain_listeners.ContainsKey( configuration_type )
                                    ? domain_listeners[ configuration_type ] 
                                    : new Collection<DomainConfiguration>();

                // Add all the configurations to the domain.
                requested_configuration
                    .Union( listeners )
                    .Do( configuration => {

                        if (!registered_configurations.Contains( configuration.GetType() )) {
                            configurations.Add( configuration );
                            registered_configurations.Add( configuration.GetType() );
                        }                                               
                    });
            }


            public ConfiguirationRegister () {
                // build up the list of listeners for each domain.
                var catalog = new AssemblyCatalog( GetType().Assembly );
                var container = new CompositionContainer( catalog );

                container
                    .GetExportedValues<DomainConfiguration>()
                    .SelectMany( l => l.services_that_the_domain_listens_for_events_from.Select( p => new { listener = l, publisher = p }))
                    .Do( n => {

                        var publisher_type = n.publisher.GetType();

                        if ( !domain_listeners.ContainsKey( publisher_type )) {
                            domain_listeners[ publisher_type  ] = new Collection<DomainConfiguration>();
                        }

                        domain_listeners[ publisher_type  ].Add( n.listener );
                    });
            }


            private readonly HashSet<Type> registered_configurations = new HashSet<Type>();
            private readonly Collection<DomainConfiguration> configurations = new Collection<DomainConfiguration>();
            private readonly Dictionary<Type, Collection<DomainConfiguration>> domain_listeners = new Dictionary<Type,Collection<DomainConfiguration>>();
        }
    }
}
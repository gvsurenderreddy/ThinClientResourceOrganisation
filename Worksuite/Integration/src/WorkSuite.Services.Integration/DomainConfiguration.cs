using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Services.Integration {

    [InheritedExport(typeof(DomainConfiguration))]
    internal abstract class DomainConfiguration {

        public IDependencyConfiguration domain_bindings { get; private set; }

        public IEnumerable<DomainConfiguration> service_need_by_the_domain {
            get { return services_needed_by_domain_repository; }
        }

        public IEnumerable<DomainConfiguration> services_that_the_domain_listens_for_events_from {
            get { return services_that_the_domain_listens_for_events_from_repository; }
        }       


        protected DomainConfiguration
            ( IDependencyConfiguration the_domain_bindings ) {

            domain_bindings = Guard.IsNotNull( the_domain_bindings, "the_domain_bindings" );

        }

        protected void register_service_needed_by_domain<T> ()
            where T : DomainConfiguration, new() {

            services_needed_by_domain_repository.Add( new T() );
        }

        protected void register_service_that_the_domain_listens_for_events_from<T> () 
            where T : DomainConfiguration, new() {
            
            services_that_the_domain_listens_for_events_from_repository.Add( new T() );
        }

        private readonly Collection<DomainConfiguration> services_needed_by_domain_repository = new Collection<DomainConfiguration>();
        private readonly Collection<DomainConfiguration> services_that_the_domain_listens_for_events_from_repository = new Collection<DomainConfiguration>();
    }
}
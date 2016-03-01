using WTS.WorkSuite.Services.Integration.ExternalServices;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.HR {

    /// <summary>
    ///     Dependency configuration for the HR domain
    /// </summary>
    internal class HRDomainConfiguration 
                    : DomainConfiguration  {

        public HRDomainConfiguration 
                       ( ) 
                : base ( new WorkSuite.HR.Infrastructure.DomainConfiguration() ) {

            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();
            register_service_needed_by_domain<ExternalServicesConfiguration>();
        }
    }
}
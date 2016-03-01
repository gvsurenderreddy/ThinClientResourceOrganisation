using WTS.WorkSuite.Services.Integration.ExternalServices;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.HR;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.Audit {

    /// <summary>
    ///     Dependency configuration for the WorkSuite service audit domain
    /// </summary>
    internal class AuditDomainConfiguration 
                    : DomainConfiguration  {

        public AuditDomainConfiguration 
                       ( ) 
                : base ( new WorkSuite.Audit.Infrastructure.DomainConfiguration() ) {

            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();
            register_service_needed_by_domain<ExternalServicesConfiguration>();


            register_service_that_the_domain_listens_for_events_from<HRDomainConfiguration>();
        }
    }
}
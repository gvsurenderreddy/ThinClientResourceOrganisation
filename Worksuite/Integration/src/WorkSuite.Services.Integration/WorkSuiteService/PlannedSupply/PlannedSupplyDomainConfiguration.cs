using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.PlannedSupply {


    /// <summary>
    ///     Dependency configuration for the PlannedSupply domain
    /// </summary>
    internal class PlannedSupplyDomainConfiguration 
                    : DomainConfiguration {

        public PlannedSupplyDomainConfiguration 
                       ( ) 
                : base ( new WTS.WorkSuite.PlannedSupply.Infrastructure.DomainConfiguration() ) {
            
            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();
        }
    }
}
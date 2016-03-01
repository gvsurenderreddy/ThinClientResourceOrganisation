using WTS.WorkSuite.Services.Integration.WorkSuiteService.HR;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;
using WTS.WorkSuite.Services.Integration.WorkSuiteService.PlannedSupply;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.Allocation {

    /// <summary>
    ///     Dependency configuration for the WorkSuite service AllocatedSupply domain
    /// </summary>
    internal class AllocationDomainConfiguration 
                    : DomainConfiguration {

        public AllocationDomainConfiguration 
                       ( ) 
                : base ( new WorkSuite.Allocation.Infrastrcuture.DomainConfiguration() ) {


            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();

            register_service_that_the_domain_listens_for_events_from<PlannedSupplyDomainConfiguration>();
        }
    }
}
using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.SupplyShortage
{


    /// <summary>
    ///     Dependency configuration for the PlannedSupply domain
    /// </summary>
    internal class SupplyShortageDomainConfiguration
                    : DomainConfiguration
    {

        public SupplyShortageDomainConfiguration
                       ()
            : base(new WTS.WorkSuite.SupplyShortage.Infrastructure.DomainConfiguration())
        {

            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();
        }
    }
}
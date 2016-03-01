using WTS.WorkSuite.Services.Integration.WorkSuiteService.Persistence;

namespace WTS.WorkSuite.Services.Integration.WorkSuiteService.ThinClientQueryDomainConfiguration
{
    /// <summary>
    ///     Dependency configuration for the ThinClientQuery domain
    /// </summary>
    internal class ThinClientQueryDomainConfiguration
                    : DomainConfiguration
    {

        public ThinClientQueryDomainConfiguration
                       ()
            : base(new ThinClient.Query.Infrastructure.DomainConfiguration())
        {

            register_service_needed_by_domain<WorkSuitePersistenceConfiguration>();
        }
    }
}

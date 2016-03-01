using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions {

    /// <summary>
    ///     Fake Maintenance session repository used instead or the real persistence layer
    /// for unit testing purposes.
    /// </summary>
    public class FakeMaintenanceSessionRepository
                    : FakeEntityRepository<MaintenanceSession, int> {

        public FakeMaintenanceSessionRepository() 
                : base( new IntIdentityProvider<MaintenanceSession>() ) { }

    }
}
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions {

    public class MaintenanceSessionHelper
                    : EnityHelper<MaintenanceSession, int, MaintenanceSessionBuilder, FakeMaintenanceSessionRepository> { }
}

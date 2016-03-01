using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Configuration.Domain.Management.ServiceStates.Queries {

    public class GetServiceStatus 
                    : IGetServiceStatus {

        public Configuration_ServiceStatusResponse execute () {

            return new Configuration_ServiceStatusResponse {
                has_errors = false,
                result = maintenance_session_repository.Entities.Any()
                            ? new ServiceIsInMaintenanceMode() as AServiceState
                            : new ServiceIsOnline() as AServiceState
            };
        }

        public GetServiceStatus
                ( IQueryRepository<MaintenanceSession> the_maintenance_session_repository ) {
            
            maintenance_session_repository = the_maintenance_session_repository;
        }

        private readonly IQueryRepository<MaintenanceSession> maintenance_session_repository;
    }
}
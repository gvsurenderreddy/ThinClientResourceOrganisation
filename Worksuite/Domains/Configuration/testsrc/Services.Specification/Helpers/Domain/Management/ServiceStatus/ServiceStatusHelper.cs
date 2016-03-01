using System.Linq;
using WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.ServiceStatus {

    /// <summary>
    ///     Test helper class that allows us to set the status of the system
    /// </summary>
    public class ServiceStatusHelper {


        public ServiceStatusHelper clear_all_maintenace_sessions() {

            maintenance_session_repository.clear();            
            return this;
        }


        public ServiceStatusHelper set_service_online () {

            service_status_repository.add( new Persistence.Domain.Configuration.ServiceStatus {
                is_online = true,
            } );

            return this;
        }


        public ServiceStatusHelper set_service_offline () {

            service_status_repository.add( new Persistence.Domain.Configuration.ServiceStatus {
                is_online = false,
            } );

            return this;            
        }


        public bool service_is_online { 

            get {

                return service_status_repository
                    .Entities
                    .OrderByDescending( e => e.id )
                    .First()
                    .is_online
                    ;
            }
        }


        public ServiceStatusHelper
                ( FakeServiceStatusRepository the_service_status_repository 
                , FakeMaintenanceSessionRepository the_maintenance_session_repository
                ) {

            service_status_repository = Guard.IsNotNull( the_service_status_repository, "the_service_status_repository" );
            maintenance_session_repository = Guard.IsNotNull(the_maintenance_session_repository, "the_maintenance_session_repository");
        }

        // repository used to set the status

        private readonly FakeServiceStatusRepository service_status_repository;
        private readonly FakeMaintenanceSessionRepository maintenance_session_repository;
    }    
}
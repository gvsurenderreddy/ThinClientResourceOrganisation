using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.GetById {

    /// <summary>
    ///     Gets the maintenance session details from the repositoty.  If the maintenance session
    /// does not exist the response is set to has errors and a null maintenances session details
    /// are returned.
    /// </summary>
    public class GetMaintenanceSessionById
                    : IGetMaintenanceSessionById {

        public GetMaintenanceSessionByIdResponse execute 
                                                    ( MaintenanceSessionIdentity request ) {

            return this
                    .set_request( request )
                    .get_maintenance_session()
                    .create_response()
                    ;
        }


        public GetMaintenanceSessionById 
                ( IEntityRepository<MaintenanceSession> the_maintenance_session_repository ) {

            maintenance_session_repository = Guard.IsNotNull( the_maintenance_session_repository, "the_maintenance_session_repository" );
        }

        private GetMaintenanceSessionById set_request
                                            ( MaintenanceSessionIdentity the_request ) {

            request = Guard.IsNotNull( the_request, "the_request" );
            response_builder = new ResponseBuilder<MaintenanceSessionDetails, GetMaintenanceSessionByIdResponse>();
            return this;
        }

        private GetMaintenanceSessionById get_maintenance_session () {

            Guard.IsNotNull( request, "request" );
            Guard.IsNotNull( response_builder, "response_builder" );

            maintenance_session = maintenance_session_repository
                                    .Entities
                                    .Where(ms => ms.id == request.maintenance_session_id)
                                    .ToList()
                                    .DefaultIfEmpty(new MaintenanceSession { id = -1 })
                                    .First()
                                    ;

            if ( maintenance_session.id == -1 ) {
                response_builder.add_error("Maintenance session does not exist");
            }
            return this;            
        }

        private GetMaintenanceSessionByIdResponse create_response() {

            Guard.IsNotNull( maintenance_session, "maintenance_session" );
            Guard.IsNotNull( response_builder, "response_builder" );

            response_builder.set_response(new MaintenanceSessionDetails {
                maintenance_session_id = maintenance_session.id,
            });
            return response_builder.build();
        }

        private readonly IEntityRepository<MaintenanceSession> maintenance_session_repository;
        private MaintenanceSessionIdentity request;
        private ResponseBuilder<MaintenanceSessionDetails, GetMaintenanceSessionByIdResponse> response_builder;
        private MaintenanceSession maintenance_session;
    }
}
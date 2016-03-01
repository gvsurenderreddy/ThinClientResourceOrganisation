using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.EndAll {

    public class EndAllMaintenanceSessions
                    : IEndAllMaintenanceSessions {

        public EndAllMaintenanceSessionsResponse execute 
                                                    ( EndAllMaintenanceSessionsRequest the_request ) {

            return this
                    .set_request( the_request )
                    .validate()
                    .end_maintenance_sessions( )
                    .commit()
                    .build_response()
                    ;
        }

        public EndAllMaintenanceSessions 
                ( IEntityRepository<MaintenanceSession> the_maintenace_session_repository 
                , IUnitOfWork the_unit_of_work ) {

            maintenace_session_repository = Guard.IsNotNull( the_maintenace_session_repository, "the_maintenace_session_repository " );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }


        private EndAllMaintenanceSessions set_request
                                            ( EndAllMaintenanceSessionsRequest the_request ) {

            request = Guard.IsNotNull( the_request, "the_request" );
            response_builder = new ResponseBuilder<EndAllMaintenanceSessionsResponse>();
            return this;
        }

        private EndAllMaintenanceSessions validate () {

            if (response_builder.has_errors) return this;

            // Improve: use the field validator as that creates response messages
            if ( !request.has_been_confirmed ) {
                response_builder.add_error( new ResponseMessage { field_name = "has_been_confirmed", message = ErrorMessages.error_00_0031 });
                response_builder.add_error( ErrorMessages.error_03_0010 );
            }
            return this;
        }

        private EndAllMaintenanceSessions end_maintenance_sessions () {

            if ( response_builder.has_errors ) return this;

            maintenace_session_repository
                .Entities
                .ToList()
                .Do(ms => maintenace_session_repository.remove(ms));
            return this;
        }

        private EndAllMaintenanceSessions commit () {

            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private EndAllMaintenanceSessionsResponse build_response() {

            if (!response_builder.has_errors) {
                response_builder.add_message( ConfirmationMessages.confirmation_04_0010 );
            }
            return response_builder.build();
        }

        private readonly IEntityRepository<MaintenanceSession> maintenace_session_repository;
        private readonly IUnitOfWork unit_of_work;

        private EndAllMaintenanceSessionsRequest request;
        private ResponseBuilder<EndAllMaintenanceSessionsResponse> response_builder =  new ResponseBuilder<EndAllMaintenanceSessionsResponse>();
    }
}
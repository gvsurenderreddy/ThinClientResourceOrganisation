using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.End {

    /// <summary>
    ///     Implementation of <see cref="IEndMaintenanceSession"/> which removes the 
    /// session from the repository if it exists.
    /// </summary>
    public class EndMaintenanceSession 
                    : IEndMaintenanceSession {

        public EndMaintenanceSessionResponse execute 
                                                ( MaintenanceSessionIdentity request ) {

            var response_builder = new ResponseBuilder<EndMaintenanceSessionResponse>();

            var maintenance_session = maintenance_session_repository
                                        .Entities
                                        .FirstOrDefault( ms => ms.id == request.maintenance_session_id  )
                                        ;

            if (maintenance_session != null) {
                maintenance_session_repository.remove( maintenance_session );
                unit_of_work.Commit();
            }
            response_builder.add_message( ConfirmationMessages.confirmation_04_0012 );
            return response_builder.build();
        }

        public EndMaintenanceSession 
                    ( IEntityRepository<MaintenanceSession> the_maintenance_session_repository
                    , IUnitOfWork the_unit_of_work ) {

            maintenance_session_repository = Guard.IsNotNull( the_maintenance_session_repository ,"the_maintenance_session_repository" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }

        private readonly IEntityRepository<MaintenanceSession> maintenance_session_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}
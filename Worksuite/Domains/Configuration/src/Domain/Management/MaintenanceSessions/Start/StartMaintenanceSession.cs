using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Persistence;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.Start {

    /// <summary>
    ///     Starts a new maintenance session which will allow an administrator to
    /// update configuration settings that can not be altered when the service is
    /// on line.
    /// </summary>
    public class StartMaintenanceSession
                    : IStartMaintenanceSession {

        /// <summary>
        ///     Creates the new maintenance session and returns its 
        /// identity
        /// </summary>
        /// <returns>
        ///     A response which contains the identity of the the 
        /// maintenance session that has just been started
        /// </returns>
        public StartMaintenanceSessionResponse execute ( ) {

            return this
                    .create_maintenance_session()
                    .commit()
                    .build_response()
                    ;
        }

        /// <summary>
        ///     Creates a new instance of the StartMaintenanceSession command
        /// </summary>
        /// <param name="the_maintenance_session_repository">
        ///     Repository that stores the maintenance sessions
        /// </param>
        /// <param name="the_unit_of_work">
        ///     Unit of work used to commit the new maintenance session
        /// </param>
        public StartMaintenanceSession 
                ( IEntityRepository<MaintenanceSession> the_maintenance_session_repository 
                , IUnitOfWork the_unit_of_work ) {
            
            maintenance_session_repository = Guard.IsNotNull( the_maintenance_session_repository , "the_maintenance_session_repository " );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }


        private StartMaintenanceSession create_maintenance_session( ) {
            
            new_maintenance_session = new MaintenanceSession(  );
            maintenance_session_repository.add( new_maintenance_session );
            return this;
        }

        private StartMaintenanceSession commit(  ) {
            
            Guard.IsNotNull( new_maintenance_session, "new_maintenance_session" );

            unit_of_work.Commit(  );
            return this;
        }

        private StartMaintenanceSessionResponse build_response( ) {
            
            Guard.IsNotNull( new_maintenance_session, "new_maintenance_session" );
            Guard.PremiseHolds( new_maintenance_session.id > 0, "new_maintenance_session has not got an identity" );

            var builder = new ResponseBuilder<MaintenanceSessionIdentity,StartMaintenanceSessionResponse>();

            builder.set_response(  new MaintenanceSessionIdentity {
                   maintenance_session_id = new_maintenance_session.id
               });

            builder.add_message( ConfirmationMessages.confirmation_04_0009 );
            
            return builder.build(  );
        }

        private readonly IEntityRepository<MaintenanceSession> maintenance_session_repository;
        private readonly IUnitOfWork unit_of_work;
        private MaintenanceSession new_maintenance_session;
        
    }
}
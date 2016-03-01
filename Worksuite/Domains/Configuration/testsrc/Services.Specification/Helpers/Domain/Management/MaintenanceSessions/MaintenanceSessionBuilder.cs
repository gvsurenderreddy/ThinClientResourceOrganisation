using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions {

    /// <summary>
    ///     Builder for MaintenanceSession.
    /// </summary>
    public class MaintenanceSessionBuilder
                    : IEntityBuilder<MaintenanceSession> {

        /// <summary>
        ///     Gets the entity.
        /// </summary>
        /// <value>
        ///     The entity.
        /// </value>
        public MaintenanceSession entity {

            get { return maintenance_session; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaintenanceSessionBuilder"/> class.
        /// </summary>
        /// <param name="the_maintenance_session">The the_employee.</param>
        public MaintenanceSessionBuilder
                    ( MaintenanceSession the_maintenance_session ) {
            
            maintenance_session = Guard.IsNotNull( the_maintenance_session, "the_maintenance_session" );
        }

        private readonly MaintenanceSession maintenance_session;

    }
}
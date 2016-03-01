using WorkSuite.Configuration.Persistence.Domain.Management;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Management.MaintenanceSessions {

    public class ModelBuilder 
                    : ModelConfiguration<MaintenanceSession> {

        public ModelBuilder
                    ( string schema ) {

            Map( m => m.ToTable( "MaintenanceSession", schema ));
        }
    }
}

using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Management {

    public class ModelBuilder 
                    : ModelConfigurationRegister {

        public ModelBuilder 
                ( string schema ) {

            register( new MaintenanceSessions.ModelBuilder( schema ));
        }

    }

}
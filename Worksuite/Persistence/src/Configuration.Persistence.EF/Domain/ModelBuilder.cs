using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain {

    public class ModelBuilder 
                    : ModelConfigurationRegister {

        public ModelBuilder ( ) {
            register( new Management.ModelBuilder( "Management" ));
            register( new Configuration.ModelBuilder( "Configuration" ));
        }

    }


}
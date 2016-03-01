using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.DocumentStore {

    public class ModelBuilder : ModelConfigurationRegister {

        public ModelBuilder ( string schema ) {

            //register( new Images.ModelBuilder( schema ) );
            register(new Documents.ModelBuilder(schema));
        }

    }

}
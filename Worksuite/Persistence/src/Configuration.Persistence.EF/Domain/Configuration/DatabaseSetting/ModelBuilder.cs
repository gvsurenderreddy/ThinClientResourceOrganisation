using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Configuration.DatabaseSetting {

    public class ModelBuilder 
                    : ModelConfiguration<DatabaseSettings> {

        public ModelBuilder
                    ( string schema ) {

            Map( m => m.ToTable( "DatabaseSettings", schema ));
        }
    }
}

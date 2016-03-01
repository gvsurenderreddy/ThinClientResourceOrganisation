using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.Addresses {

    public class ModelBuilder 
                    : ModelConfiguration<Address> {

        public ModelBuilder
                ( string schema ) {

            Map( m => m.ToTable("Address", schema ));
        }
    }
}
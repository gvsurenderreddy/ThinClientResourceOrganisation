using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Gender {

    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Gender>  {

        public ModelBuilder
                    ( string schema ) {

            Map( m => m.ToTable("Gender", schema ));
        }
    }

}
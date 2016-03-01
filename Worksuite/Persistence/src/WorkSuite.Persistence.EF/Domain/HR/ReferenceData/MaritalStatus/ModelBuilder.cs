using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.MaritalStatus {

    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.MaritalStatus>  {

        public ModelBuilder
                    ( string schema ) {

            Map( m => m.ToTable("MaritalStatus", schema ));
        }
    }

}
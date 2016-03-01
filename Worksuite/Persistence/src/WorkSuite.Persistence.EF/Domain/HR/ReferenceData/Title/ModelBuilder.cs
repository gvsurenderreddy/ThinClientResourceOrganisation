using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Title {

    public class ModelBuilder : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Title>  {

        public ModelBuilder( string schema ) {

            Map(m => m.ToTable("Title", schema ));
        }

    }

}
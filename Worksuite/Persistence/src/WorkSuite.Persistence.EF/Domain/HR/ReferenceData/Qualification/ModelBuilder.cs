using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Qualification
{
    public class ModelBuilder
                        :   ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Qualification>
    {
        public ModelBuilder( string schema )
        {
            Map(m => m.ToTable("Qualification", schema));
        }
    }
}

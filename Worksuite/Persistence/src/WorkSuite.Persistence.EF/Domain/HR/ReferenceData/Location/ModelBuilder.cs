using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Location
{
    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Location>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("Location", schema));
        }
    }
}
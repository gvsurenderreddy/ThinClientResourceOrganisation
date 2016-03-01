using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Relationship
{
    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Relationship>
    {

        public ModelBuilder
                    (string schema)
        {

            Map(m => m.ToTable("Relationship", schema));
        }
    }
}
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.JobTitle
{
    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.HR.HR.ReferenceData.JobTitle>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("JobTitle", schema));
        }
    }
}
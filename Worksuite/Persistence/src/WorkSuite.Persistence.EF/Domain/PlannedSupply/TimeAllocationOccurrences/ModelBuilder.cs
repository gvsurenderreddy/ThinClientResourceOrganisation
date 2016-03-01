using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.TimeAllocationOccurrences
{
    public class ModelBuilder
                    : ModelConfiguration<TimeAllocationOccurrence>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("TimeAllocationOccurrence", schema));

            Property(u => u.start_date).HasColumnType("datetime2");
        }
    }
}
using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.TimeAllocations
{
    public class ModelBuilder
                    : ModelConfiguration<TimeAllocation>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("TimeAllocation", schema));

            HasMany(m => m.TimeAllocationBreaks)
                .WithRequired();
        }
    }
}
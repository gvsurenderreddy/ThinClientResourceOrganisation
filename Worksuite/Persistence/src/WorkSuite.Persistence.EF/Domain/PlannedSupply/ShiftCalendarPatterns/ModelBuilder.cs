using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.ShiftCalendarPatterns
{
    public class ModelBuilder
                    : ModelConfiguration<WorkSuite.PlannedSupply.ShiftCalendarPatterns.ShiftCalendarPattern>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ShiftCalendarPattern", schema));

            HasMany(m => m.TimeAllocationOccurrences)
                .WithRequired();

            HasMany(m => m.ResourceAllocations)
                .WithRequired();

        }
    }
}
using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.TimeAllocationBreaks
{
    public class ModelBuilder : ModelConfiguration<TimeAllocationBreak>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("TimeAllocationBreak", schema));
        }
    }
}
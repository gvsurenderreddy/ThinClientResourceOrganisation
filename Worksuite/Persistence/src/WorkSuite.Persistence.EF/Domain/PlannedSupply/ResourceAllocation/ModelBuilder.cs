using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.ResourceAllocation
{
    public class ModelBuilder : ModelConfiguration<WTS.WorkSuite.PlannedSupply.ResourceAllocations.ResourceAllocation>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ResourceAllocation", schema));
        }
    }
}

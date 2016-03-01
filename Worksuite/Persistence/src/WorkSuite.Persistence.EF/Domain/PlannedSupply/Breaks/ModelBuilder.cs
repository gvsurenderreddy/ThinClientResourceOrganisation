using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.Breaks
{
    public class ModelBuilder : ModelConfiguration<WorkSuite.PlannedSupply.Breaks.Break>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("Break", schema));
        }
    }
}
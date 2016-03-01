using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.ShiftBreakTemplates
{
    public class ModelBuilder
                    : ModelConfiguration<BreakTemplate>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ShiftBreakTemplate", schema));

            // Set up cascading delete on Collection Navigation properties
            HasMany(m => m.all_breaks)
                .WithRequired()
                ;
        }
    }
}
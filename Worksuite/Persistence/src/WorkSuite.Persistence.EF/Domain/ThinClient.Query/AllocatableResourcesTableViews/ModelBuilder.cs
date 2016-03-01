using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.AllocatableResourcesTableViews
{
    public class ModelBuilder : ModelConfiguration<AllocatableResourcesTableView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("AllocatableResourcesTableView", schema));
        }
    }
}

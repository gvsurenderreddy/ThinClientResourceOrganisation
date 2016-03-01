using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.AllocatedResourcesListViews
{
    public class ModelBuilder : ModelConfiguration<AllocatedResourcesListView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("AllocatedResourcesListView", schema));
        }
    }
}

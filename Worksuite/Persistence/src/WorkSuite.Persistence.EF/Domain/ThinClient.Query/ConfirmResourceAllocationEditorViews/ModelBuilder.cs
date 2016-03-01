using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.ConfirmResourceAllocationEditorViews
{
    public class ModelBuilder : ModelConfiguration<ConfirmResourceAllocationEditorView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ConfirmResourceAllocationEditorView", schema));
        }
    }
}

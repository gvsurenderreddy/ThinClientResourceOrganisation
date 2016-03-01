using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup
{
    public class FindConfirmResourceAllocationEditorViewHelper : EnityHelper<ConfirmResourceAllocationEditorView
                                                   ,int  
                                                   ,FindConfirmResourceAllocationEditorViewBuilder
                                                   ,FakeConfirmResourceAllocationEditorViewRepository> {}
}

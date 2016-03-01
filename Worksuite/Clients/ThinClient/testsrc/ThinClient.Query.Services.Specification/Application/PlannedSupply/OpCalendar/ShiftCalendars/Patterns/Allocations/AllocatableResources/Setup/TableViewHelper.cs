using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup
{
    public class FindAllocatableResourcesTableViewHelper : EnityHelper<AllocatableResourcesTableView
                                                   ,int  
                                                   ,FindAllocatableResourcesTableViewBuilder
                                                   ,FakeAllocatableResourcesViewRepository> {}
}

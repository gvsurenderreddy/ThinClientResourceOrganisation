using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup
{
    public class FindAllocatedResourcesListViewHelper : EnityHelper<AllocatedResourcesListView
                                                   ,int  
                                                   ,FindAllocatedResourcesListViewBuilder
                                                   ,FakeAllocatedResourcesListViewRepository> {}
}

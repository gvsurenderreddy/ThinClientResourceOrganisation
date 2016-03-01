using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup
{
   public class FakeAllocatedResourcesListViewRepository : FakeEntityRepository<AllocatedResourcesListView,int>
   {
       public FakeAllocatedResourcesListViewRepository(): base(new IntIdentityProvider<AllocatedResourcesListView>())
       {
       }
   }
}

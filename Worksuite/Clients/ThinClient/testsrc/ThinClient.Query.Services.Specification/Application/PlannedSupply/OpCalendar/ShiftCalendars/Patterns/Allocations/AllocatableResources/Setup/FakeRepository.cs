using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup
{
   public class FakeAllocatableResourcesViewRepository : FakeEntityRepository<AllocatableResourcesTableView,int>
   {
       public FakeAllocatableResourcesViewRepository() : base ( new IntIdentityProvider<AllocatableResourcesTableView>())
       {
       }
   }
}

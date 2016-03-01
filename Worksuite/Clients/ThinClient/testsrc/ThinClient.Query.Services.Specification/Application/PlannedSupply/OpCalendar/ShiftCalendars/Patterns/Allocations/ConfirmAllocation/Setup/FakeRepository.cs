using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup
{
   public class FakeConfirmResourceAllocationEditorViewRepository : FakeEntityRepository<ConfirmResourceAllocationEditorView,int>
   {
       public FakeConfirmResourceAllocationEditorViewRepository(): base(new IntIdentityProvider<ConfirmResourceAllocationEditorView>())
       {
       }
   }
}

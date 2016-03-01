using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Fields;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup
{
   public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IEntityRepository<AllocatableResourcesTableView>, FakeAllocatableResourcesViewRepository>()
                .To<FakeAllocatableResourcesViewRepository>()
                .InScope(scope)
                ;
            kernel
                .Rebind<IGetResourceAllocationsByShiftCalendar>()
                .To<FakeGetResourceAllocationsByShiftCalendar>()
                 .InScope(scope);
        }
    }
}

using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;
using WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Fields;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Setup
{
   public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IEntityRepository<ConfirmResourceAllocationEditorView>, FakeConfirmResourceAllocationEditorViewRepository>()
                .To<FakeConfirmResourceAllocationEditorViewRepository>()
                .InScope(scope)
                ;
          
            kernel
            .Rebind<IGetAllocateEmployeeToPatternRequestHandler>()
            .To<FakeGetAllocateEmployeeToPatternRequest>()
             .InScope(scope);
        }
    }
}

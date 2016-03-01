using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.post;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.get;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.post;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation
{
    public class ResourceAllocationQueryDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetResourceAllocationsByShiftCalendarPattern>()
                .To<GetResourceAllocationsByShiftCalendarPattern>()
                ;

            kernel
                .Bind<IGetResourceAllocationsByShiftCalendar>()
                .To<GetResourceAllocationsByShiftCalendar>()
                ;

            kernel
                .Bind<IGetAllocateEmployeeToPatternRequestHandler>()
                .To<GetAllocateEmployeeToPatternRequestHandler>()
                ;

            kernel
              .Bind<IRemoveResourceAllocationFromPatternRequestHandler>()
              .To<RemoveResourceAllocationFromPattern>()
              ;

            kernel
              .Bind<IAllocateEmployeeToPatternRequestHandler>()
              .To<AllocateEmployeeToPatternRequestHandler>()
              ;

            kernel
              .Bind<IGetRemoveResourceAllocationFromPatternRequestHandler>()
              .To<GetRemoveResourceAllocationFromPatternRequest>()
              ;
        }
    }
}

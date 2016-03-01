using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport
{
   public class DependencyConfiguration : ADependencyConfiguration
    {
       public override void configure(IKernel kernel, Func<IContext, object> scope)
       {
           kernel
             .Bind<IGetAllocatedResources>()
             .To<GetAllocatedResources>();
       }
    }
}

using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetRemoveShiftBreakRequest>()
                .To<GetRemoveShiftBreakRequest>()
                ;

            kernel
                .Bind<IRemoveShiftBreak>()
                .To<RemoveShiftBreak>()
                ;

            kernel
               .Bind<IRemoveShiftBreakForAllOccurrences>()
               .To<RemoveShiftBreakForAllOccurrences>()
               ;
        }
    }
}
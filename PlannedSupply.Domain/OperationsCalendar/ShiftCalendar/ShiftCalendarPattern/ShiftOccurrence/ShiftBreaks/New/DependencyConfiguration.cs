using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetNewShiftBreakRequest>()
                .To<GetNewShiftBreakRequest>()
                ;

            kernel
                .Bind<INewShiftBreak>()
                .To<NewShiftBreak>()
                ;

            kernel
                .Bind<INewShiftBreakForAllOccurrences>()
                .To<NewShiftBreakForAllOccurrences>()
                ;
        }
    }
}
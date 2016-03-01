using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetEditShiftBreakRequest>()
                .To<GetEditShiftBreakRequest>()
                ;

            kernel
                .Bind<IEditShiftBreak>()
                .To<EditShiftBreak>()
                ;

            kernel
                .Bind<IEditShiftBreakForAllOccurrences>()
                .To<EditShiftBreakForAllOccurrences>()
                ;
        }
    }
}
using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IApplyShiftBreaksFromBreakTemplate>()
                .To<ApplyShiftBreaksFromBreakTemplate>()
                ;

            kernel
                .Bind<IApplyShiftBreaksFromBreakTemplateForAllOccurrences>()
                .To<ApplyShiftBreaksFromBreakTemplateForAllOccurrences>()
                ;

            kernel
                .Bind<IGetApplyShiftBreaksFromBreakTemplateRequest>()
                .To<GetApplyShiftBreaksFromBreakTemplateRequest>()
                ;
        }
    }
}
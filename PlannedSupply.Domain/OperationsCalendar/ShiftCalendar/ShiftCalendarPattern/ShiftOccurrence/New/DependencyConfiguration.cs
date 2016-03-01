using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New
{
    public class DependencyConfiguration
                         : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<INewShiftOccurrence>()
               .To<NewShiftOccurrence>();

            kernel.Bind<IGetNewShiftOccurrenceRequest>()
               .To<GetNewShiftOccurrenceRequest>();

        }
    }
}
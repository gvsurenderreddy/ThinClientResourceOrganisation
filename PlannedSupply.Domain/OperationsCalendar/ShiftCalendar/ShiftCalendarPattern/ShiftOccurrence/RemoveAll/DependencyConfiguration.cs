using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public class DependencyConfiguration :ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IRemoveAllShiftOccurrences>()
                .To<RemoveAllShiftOccurrences>();

            kernel
                .Bind<IGetRemoveAllShiftOccurrencesRequest>()
                .To<GetRemoveAllShiftOccurrencesRequest>();

        }
    }
}
using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public class RemoveShiftCalendarPatternDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IRemoveShiftCalendarPattern>()
                .To<RemoveShiftCalendarPattern>()
                ;

            kernel
                .Bind<IGetRemoveShiftCalendarPatternRequest>()
                .To<GetRemoveShiftCalendarPatternRequest>()
                ;
        }
    }
}
using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove
{
    public class RemoveShiftCalendarDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IRemoveShiftCalendar>()
                .To<RemoveShiftCalendar>()
                ;

            kernel
                .Bind<IGetRemoveShiftCalendarRequest>()
                .To<GetRemoveShiftCalendarRequest>()
                ;
        }
    }
}
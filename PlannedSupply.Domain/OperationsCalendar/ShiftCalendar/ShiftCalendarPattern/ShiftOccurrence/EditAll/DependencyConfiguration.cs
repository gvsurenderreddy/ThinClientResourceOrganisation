using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetEditAllShiftOccurrencesRequest>()
                .To<GetEditAllShiftOccurrencesRequest>()
                ;

            kernel
                .Bind<IEditAllShiftOccurrences>()
                .To<EditAllShiftOccurrences>()
                ;
        }
    }
}
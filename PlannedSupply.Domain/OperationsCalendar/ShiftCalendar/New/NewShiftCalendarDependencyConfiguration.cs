using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New
{
    public class NewShiftCalendarDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetNewShiftCalendarRequest>()
                .To<GetNewShiftCalendarRequest>()
                ;

            kernel
                .Bind<INewShiftCalendar>()
                .To<NewShiftCalendar>()
                ;

            kernel
                .Bind<ICanAddNewShiftCalendar>()
                .To<CanAddNewShiftCalendar>()
                ;
        }
    }
}
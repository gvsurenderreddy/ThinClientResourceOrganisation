using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New
{
    public class NewShiftCalendarPatternDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetNewShiftCalendarPatternRequest>()
                .To<GetNewShiftCalendarPatternRequest>()
                ;

            kernel
                .Bind<ICanAddNewShiftCalendarPattern>()
                .To<CanAddNewShiftCalendarPattern>()
                ;

            kernel
                .Bind<INewShiftCalendarPattern>()
                .To<NewShiftCalendarPattern>()
                ;
        }
    }
}
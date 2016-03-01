using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit
{
    public class UpdateShiftCalendarPatternDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetUpdateShiftCalendarPatternRequest>()
                .To<GetUpdateShiftCalendarPatternRequest>()
                ;

            kernel
                .Bind<ICanUpdateShiftCalendarPattern>()
                .To<CanUpdateShiftCalendarPattern>()
                ;

            kernel
                .Bind<IUpdateShiftCalendarPattern>()
                .To<UpdateShiftCalendarPattern>()
                ;
        }
    }
}
using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit
{
    public class UpdateShiftCalendarDependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetUpdateShiftCalendarRequest>()
                .To<GetUpdateShiftCalendarRequest>()
                ;

            kernel
                .Bind<ICanUpdateShiftCalendar>()
                .To<CanUpdateShiftCalendar>()
                ;

            kernel
                .Bind<IUpdateShiftCalendar>()
                .To<UpdateShiftCalendar>()
                ;
        }
    }
}
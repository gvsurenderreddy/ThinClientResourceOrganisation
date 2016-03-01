using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.Allocation.OperationCalendars.ShiftCalendars.New {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IEventSubscriber<ShiftCalendarCreatedEvent>>()
                .To<CreateShiftCalendarOnShiftCalendarCreatedEvent>()
                .InScope( scope )
                ;
        }
    }
}
using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;

namespace WTS.WorkSuite.Allocation.OperationCalendars.New {

    public class DependencyConfiguration
                     : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope) {

            kernel
                .Bind<IEventSubscriber<OperationCalendarCreatedEvent>>()
                .To<CreateOperationCalendarOnOperationsCalendarCreatedEvent>()
                .InScope(scope)
                ;
        }
    }
}
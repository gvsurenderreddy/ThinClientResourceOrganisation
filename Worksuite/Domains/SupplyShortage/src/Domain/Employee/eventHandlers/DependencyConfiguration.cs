using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.SupplyShortage.Employee.eventHandlers
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure( IKernel kernel, Func<IContext, object> scope )
        {
            kernel
               .Bind<IEventSubscriber<EmployeeCreatedEvent>> ( )
               .To<CreateEmployeeSupplyShortageWhenEmployeeCreated> ( )
               .InScope( scope )
               ;

            kernel
               .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
               .To<RemoveEmployeeSupplyShortageWhenEmployeeRemoved>()
               .InScope(scope)
               ;

        }
    }
}

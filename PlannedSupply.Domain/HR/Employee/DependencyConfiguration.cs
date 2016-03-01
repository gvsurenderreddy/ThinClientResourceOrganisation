using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.HR.Employee
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IEventSubscriber<EmployeeCreatedEvent>>()
               .To<CreateEmployeePlannedSupplyWhenEmployeeCreated>()
               .InScope(scope)
               ;


            kernel
               .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
               .To<RemoveEmployeePlannedSupplyWhenEmployeeRemoved>()
               .InScope(scope)
               ;
        }
    }
}

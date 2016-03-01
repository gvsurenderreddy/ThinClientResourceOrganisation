using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.eventHandlers
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                 .Bind<IEventSubscriber<SicknessCreatedEvent>>()
                .To<SicknessCreatedEventHandler>()
                ;
            kernel
                 .Bind<IEventSubscriber<SicknessRemovedEvent>>()
                .To<SicknessRemovedEventHandler>()
                ;

            kernel
                 .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
                .To<RemoveEmployeeSicknessesWhenEmployeeRemoved>()
                ;
        }
    }
}

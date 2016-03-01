using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.SupplyShortage.Employee.Holiday.events;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.eventHandlers
{
    public class HolidayCreatedEventHandlerDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope)
        {
            kernel
                .Bind<IEventSubscriber<HolidayCreatedEvent>>()
                .To<HolidayCreatedEventHandler>()
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
                .To<RemoveEmployeeHolidaysWhenEmployeeRemoved>()
                ;

            kernel
                .Bind<IEventSubscriber<HolidayRemovedEvent>>()
               .To<HolidayRemovedEventHandler>()
               ;
        }
    }
}

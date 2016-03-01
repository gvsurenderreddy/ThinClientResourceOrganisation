using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Image
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IEventSubscriber<EmployeeImageDetailsUpdatedEvent>>()
                .To<AddImageDetailsAuditRecordWhenImageIsUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeImageDetailsRemovedEvent>>()
                .To<AddImageDetailsAuditRecordWhenImageIsRemoved>()
                .InScope(scope)
                ;
        }
    }
}
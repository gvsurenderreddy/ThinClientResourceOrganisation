using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Address
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IEventSubscriber<EmployeeAddressDetailsCreatedEvent>>()
                .To<AddAddressDetailsAuditRecordWhenAddressIsCreated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeAddressDetailsUpdatedEvent>>()
                .To<AddAddressDetailsAuditRecordWhenAddressIsUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeAddressRemovedEvent>>()
                .To<AddAddressDetailsAuditRecordWhenAddressIsRemoved>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeAddressAutoReorderedEvent>>()
                .To<AddAddressDetailsAuditRecordWhenAddressIsAutomaticallyReordered>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeAddressManualReorderedEvent>>()
                .To<AddAddressDetailsAuditRecordWhenAddressIsManuallyReordered>()
                .InScope(scope)
                ;
        }
    }
}
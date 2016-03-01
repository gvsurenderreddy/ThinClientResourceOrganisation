using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.EmergencyContact
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IEventSubscriber<EmployeeEmergencyContactDetailsCreateEvent>>()
               .To<AddEmergencyContactDetailsAuditRecordWhenContactIsCreated>()
               .InScope(scope)
               ;

            kernel
              .Bind<IEventSubscriber<EmployeeEmergencyContactDetailsUpdateEvent>>()
              .To<AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsUpdated>()
              .InScope(scope)
              ;

            kernel
               .Bind<IEventSubscriber<EmployeeEmergencyContactDetailsRemoveEvent>>()
               .To<AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved>()
               .InScope(scope)
               ;
            kernel
               .Bind<IEventSubscriber<EmployeeEmergencyContactAutoReorderedEvent>>()
               .To<AddEmergencyContactAuditRecordWhenEmergencyContactIsAutomaticallyReordered>()
               .InScope(scope)
               ;

            kernel
                .Bind<IEventSubscriber<EmployeeEmergencyContactManualReorderedEvent>>()
                .To<AddEmergencyContactAuditRecordWhenEmergencyContactIsManuallyReordered>()
                .InScope(scope)
                ;
        }
    }
}
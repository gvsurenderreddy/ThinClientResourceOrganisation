using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.Notes.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Notes
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
               .Bind<IEventSubscriber<EmployeeNoteCreatedEvent>>()
               .To<AddNoteDetailsAuditRecordWhenNoteIsCreated>()
               .InScope(scope)
               ;

            kernel
               .Bind<IEventSubscriber<EmployeeNoteUpdatedEvent>>()
               .To<AddNoteDetailsAuditRecordWhenNoteIsUpdated>()
               .InScope(scope)
               ;

            kernel
               .Bind<IEventSubscriber<EmployeeNoteRemovedEvent>>()
               .To<AddNoteDetailsAuditRecordWhenNoteIsRemoved>()
               .InScope(scope)
               ;
        }
    }
}
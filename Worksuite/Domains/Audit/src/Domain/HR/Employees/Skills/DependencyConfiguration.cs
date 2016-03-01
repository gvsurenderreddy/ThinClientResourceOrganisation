using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Skills
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
               .Bind<IEventSubscriber<EmployeeSkillCreatedEvent>>()
               .To<AddSkillDetailsAuditRecordWhenSkillIsCreated>()
               .InScope(scope)
               ;

            kernel
                .Bind<IEventSubscriber<EmployeeSkillAutoReorderedEvent>>()
                .To<AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsAutomaticallyReordered>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeSkillManualReorderedEvent>>()
                .To<AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsManuallyReordered>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeSkillRemovedEvent>>()
                .To<AddSkillDetailsAuditRecordWhenAnEmployeeSkillIsRemoved>()
                .InScope(scope)
                ;
        }
    }
}
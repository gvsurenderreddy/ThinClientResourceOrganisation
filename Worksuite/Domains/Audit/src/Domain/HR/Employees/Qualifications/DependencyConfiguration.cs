using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Qualifications
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
               .Bind<IEventSubscriber<EmployeeQualificationCreatedEvent>>()
               .To<AddQualificationDetailsAuditRecordWhenEmployeeQualificationIsCreated>()
               .InScope(scope)
               ;

            kernel
                .Bind<IEventSubscriber<EmployeeQualificationRemovedEvent>>()
                .To<AddQualificationDetailsAuditRecordWhenAnEmployeeQualificationIsRemoved>()
                .InScope(scope)
                ;
        }
    }
}
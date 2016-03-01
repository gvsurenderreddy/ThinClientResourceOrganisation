using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class DependencyConfiguration
                     : ADependencyConfiguration
    {
        public override void configure
                                (IKernel kernel
                                , Func<IContext, object> scope)
        {
            kernel
                .Bind<IEventSubscriber<EmployeeCreatedEvent>>()
                .To<CreateEmployeeAuditTrailWhenEmployeeCreated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeEmploymentDetailsUpdatedEvent>>()
                .To<AddEmploymentDetailsAduitRecordWhenUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>>()
                .To<AddPersonalDetailsAduitRecordWhenUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeContactDetailsUpdatedEvent>>()
                .To<AddContactDetailsAuditRecordWhenUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
                .To<WipeEmployeesAuditTrailWhenRemoved>()
                .InScope(scope)
                ;
        }
    }
}
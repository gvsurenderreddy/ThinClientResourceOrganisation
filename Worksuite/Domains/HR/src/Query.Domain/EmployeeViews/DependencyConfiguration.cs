using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Query.EmployeeViews
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IEventSubscriber<EmployeeCreatedEvent>>()
                .To<CreateEmployeeViewWhenEmployeeCreated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeeRemovedEvent>>()
                .To<RemoveEmployeeViewWhenEmployeeRemoved>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>>()
                .To<UpdateEmployeeViewWhenPersonalDetailsUpdated>()
                .InScope(scope)
                ;


            kernel
                .Bind<IEventSubscriber<EmployeeEmploymentDetailsUpdatedEvent>>()
                .To<UpdateEmployeeViewWhenEmploymentDetailsUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<JobTitleUpdatedEvent>>()
                .To<UpdateEmployeeViewsWhenJobTitleUpdated>()
                .InScope(scope)
                ;

            kernel
                .Bind<IEventSubscriber<LocationUpdatedEvent>>()
                .To<UpdateEmployeeViewsWhenLocationUpdated>()
                .InScope(scope)
                ;

            
        }
    }
}

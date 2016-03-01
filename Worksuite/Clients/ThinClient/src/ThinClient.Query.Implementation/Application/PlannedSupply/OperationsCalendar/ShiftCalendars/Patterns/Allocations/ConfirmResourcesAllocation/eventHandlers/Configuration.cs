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

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.eventHandlers
{
    public class DependencyConfiguration :ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IEventSubscriber<EmployeeCreatedEvent>>()
                .To<AddConfirmResourceAllocationEditorViewWhenEmployeeCreated>()
                .InScope(scope);

            kernel.Bind<IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>>()
               .To<UpdateConfirmResourceAllocationEditorViewWhenEmployeePersonalDetailsEventUpdated>()
               .InScope(scope);

            kernel.Bind<IEventSubscriber<EmployeeRemovedEvent>>()
              .To<RemoveConfirmResourceAllocationEditorViewWhenEmployeeRemoved>()
              .InScope(scope);

             kernel.Bind<IEventSubscriber<JobTitleUpdatedEvent>>()
              .To<UpdateConfirmResourceAllocationEditorViewWhenEmployeeJobTitleUpdated>()
              .InScope(scope);

             kernel.Bind<IEventSubscriber<EmployeeEmploymentDetailsUpdatedEvent>>()
              .To<UpdateConfirmResourceAllocationEditorViewWhenEmploymentDetailsUpdated>()
              .InScope(scope);

             kernel.Bind<IEventSubscriber<LocationUpdatedEvent>>()
              .To<UpdateConfirmResourceAllocationEditorViewWhenLocationUpdated>()
              .InScope(scope);
            

        }
    }
}

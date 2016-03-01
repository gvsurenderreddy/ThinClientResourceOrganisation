using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers
{
    public class UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated : IEventSubscriber<JobTitleUpdatedEvent>
    {
        public void handle(JobTitleUpdatedEvent the_event_to_handle)
        {
                 set_event(the_event_to_handle)
                .find_employee()
                .update_employee()
                .commit();
        }

        private UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated set_event(JobTitleUpdatedEvent the_event_to_handle)
        {
           jobtitle_updated_event= Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            return this;
        }

        private UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated find_employee()
        {
            Guard.IsNotNull(jobtitle_updated_event, "jobtitle_updated_event");

          employee_views =  employee_view_repository
                                         .Entities
                                         .Where(x => x.job_title_id == jobtitle_updated_event.id);
            return this;
        }

        private UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated update_employee()
        {
            Guard.IsNotNull(jobtitle_updated_event, "jobtitle_updated_event");
            Guard.IsNotNull(employee_views, "employee_views");

            employee_views.Do(jo => { jo.job_title = jobtitle_updated_event.description; });
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public UpdateAllocatableResourcesTableItemWhenEmployeeJobTitleUpdated( IEntityRepository<AllocatableResourcesTableView> employee_view_repository
                                                                             , IUnitOfWork unit_of_work)
        {
            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }

        private JobTitleUpdatedEvent jobtitle_updated_event;
        private IEnumerable<AllocatableResourcesTableView> employee_views;

        private readonly IEntityRepository<AllocatableResourcesTableView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}

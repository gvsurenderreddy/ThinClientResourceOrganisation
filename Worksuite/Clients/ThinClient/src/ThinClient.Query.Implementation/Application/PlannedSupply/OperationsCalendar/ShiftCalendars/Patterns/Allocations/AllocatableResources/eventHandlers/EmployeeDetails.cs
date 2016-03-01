using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers
{
    public class UpdateAllocatableResourcesTableItemWhenEmploymentDetailsUpdated : IEventSubscriber<EmployeeEmploymentDetailsUpdatedEvent>
    {
        public void handle(EmployeeEmploymentDetailsUpdatedEvent the_event_to_handle)
        {
                 set_event(the_event_to_handle)
                .find_employee_view()
                .update_employee()
                .commit()
                ; 
        }

        private UpdateAllocatableResourcesTableItemWhenEmploymentDetailsUpdated set_event
                                                               (EmployeeEmploymentDetailsUpdatedEvent the_event_to_handle)
        {
            employment_details_updated_event = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            return this;
        }

        private UpdateAllocatableResourcesTableItemWhenEmploymentDetailsUpdated find_employee_view ()
        {
            Guard.IsNotNull(employment_details_updated_event, "employment_details_updated_event");
            employee_view = employee_view_repository
                                         .Entities
                                         .Single(x => x.employee_id == employment_details_updated_event.employee_id);
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        private UpdateAllocatableResourcesTableItemWhenEmploymentDetailsUpdated update_employee()
        {
            Guard.IsNotNull(employment_details_updated_event, "employment_details_updated_event");
            Guard.IsNotNull(employee_view, "employee_view");

            employee_view.employee_reference = employment_details_updated_event.employee_reference;
            employee_view.job_title = employment_details_updated_event.job_title_description;
            employee_view.job_title_id = employment_details_updated_event.job_title_id.GetValueOrDefault(Null.Id);
            employee_view.location = employment_details_updated_event.location_description;
            employee_view.location_id = employment_details_updated_event.location_id.GetValueOrDefault(Null.Id);
            return this;
        }

        public UpdateAllocatableResourcesTableItemWhenEmploymentDetailsUpdated( IEntityRepository<AllocatableResourcesTableView> employee_view_repository
                                                                              , IUnitOfWork unit_of_work)
        {
            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }

        private EmployeeEmploymentDetailsUpdatedEvent employment_details_updated_event;
        private AllocatableResourcesTableView employee_view;

        private readonly IEntityRepository<AllocatableResourcesTableView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}

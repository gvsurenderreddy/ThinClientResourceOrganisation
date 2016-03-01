using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.eventHandlers
{
    public class UpdateAllocatedResourcesListViewWhenEmployeePersonalDetailsEventUpdated : IEventSubscriber<EmployeePersonalDetailsUpdatedEvent>
    {
        public void handle(EmployeePersonalDetailsUpdatedEvent the_event_to_handle)
        {
                 set_event(the_event_to_handle)
                .find_employee()
                .update_employee()
                .commit();
        }

        private UpdateAllocatedResourcesListViewWhenEmployeePersonalDetailsEventUpdated set_event( EmployeePersonalDetailsUpdatedEvent the_event_to_handle)
        {
            employee_details_updated_event = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            return this;
        }
        private UpdateAllocatedResourcesListViewWhenEmployeePersonalDetailsEventUpdated find_employee()
        {
            Guard.IsNotNull(employee_details_updated_event, "employee_details_updated_event");
            find_employee_table_view = find_employee_table_view_repository
                                      .Entities
                                      .Single(x => x.employee_id == employee_details_updated_event.employee_id);
                            
            return this;
        }

        private UpdateAllocatedResourcesListViewWhenEmployeePersonalDetailsEventUpdated update_employee()
        {
            Guard.IsNotNull(employee_details_updated_event, "employee_details_updated_event");
            Guard.IsNotNull(find_employee_table_view, "find_employee_table_view");

            find_employee_table_view.name = employee_details_updated_event.forename + " " + employee_details_updated_event.surname;
            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public UpdateAllocatedResourcesListViewWhenEmployeePersonalDetailsEventUpdated(IEntityRepository<AllocatedResourcesListView> find_employee_table_view_repository
                                                                                       , IUnitOfWork unit_of_work)
        {
            this.find_employee_table_view_repository = Guard.IsNotNull(find_employee_table_view_repository,"find_employee_table_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }

        private EmployeePersonalDetailsUpdatedEvent employee_details_updated_event;
        private AllocatedResourcesListView find_employee_table_view;

        private readonly IEntityRepository<AllocatedResourcesListView> find_employee_table_view_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}

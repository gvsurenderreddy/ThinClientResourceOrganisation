using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.eventHandlers
{
    public class RemoveAllocatedResourcesListViewWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
   {
        public void handle(EmployeeRemovedEvent the_event_to_handle)
        {
                 set_event(the_event_to_handle)
                .find_employee()
                .remove_employee()
                .commit();
        }

        private RemoveAllocatedResourcesListViewWhenEmployeeRemoved set_event( EmployeeRemovedEvent the_event_to_handle )
        {
            employee_removed_event = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            return this;
        }

        private RemoveAllocatedResourcesListViewWhenEmployeeRemoved find_employee()
        {
            Guard.IsNotNull(employee_removed_event, "employee_removed_event");

          find_employee_table_view =  employee_view_repository
                .Entities.Single(x => x.employee_id == employee_removed_event.employee_id);
            return this;
        }

        private RemoveAllocatedResourcesListViewWhenEmployeeRemoved remove_employee()
        {
            Guard.IsNotNull(find_employee_table_view, "find_employee_table_view");

            employee_view_repository.remove(find_employee_table_view);

            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public RemoveAllocatedResourcesListViewWhenEmployeeRemoved(IEntityRepository<AllocatedResourcesListView> employee_view_repository
                                                                     , IUnitOfWork unit_of_work)
        {
            this.employee_view_repository = Guard.IsNotNull(employee_view_repository, "employee_view_repository");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
        }

        public EmployeeRemovedEvent employee_removed_event;
        public AllocatedResourcesListView find_employee_table_view;
        private readonly IEntityRepository<AllocatedResourcesListView> employee_view_repository;
        private readonly IUnitOfWork unit_of_work;

   }
}

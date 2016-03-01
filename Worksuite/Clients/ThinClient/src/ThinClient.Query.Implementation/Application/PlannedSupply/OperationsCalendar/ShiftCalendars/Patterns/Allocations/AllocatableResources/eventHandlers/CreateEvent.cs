using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.eventHandlers
{
    public class AddAllocatableResourcesTableItemWhenEmployeeCreated :IEventSubscriber<EmployeeCreatedEvent>
    {
        public void handle(EmployeeCreatedEvent the_event_to_handle)
        {
                create_entity(the_event_to_handle)
               .add_to_repository()
               .commit();
        }

        private AddAllocatableResourcesTableItemWhenEmployeeCreated create_entity(EmployeeCreatedEvent the_event_to_handle)
        {
            Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");

             find_employee_table_view=new AllocatableResourcesTableView
             {
                 employee_id = the_event_to_handle.employee_id,
                 employee_reference = the_event_to_handle.employee_reference,
                 forename = the_event_to_handle.forename,
                 surname = the_event_to_handle.surname
             };
            return this;
        }
        private AddAllocatableResourcesTableItemWhenEmployeeCreated add_to_repository()
        {
            Guard.IsNotNull(find_employee_table_view, "find_employee_table_view");

            employee_entity_repository.add(find_employee_table_view);
            return this;
        }

        private void commit()
        {
           unit_of_work.Commit();
        }

        public AddAllocatableResourcesTableItemWhenEmployeeCreated( IEntityRepository<AllocatableResourcesTableView> employee_entity_repository
                                             , IUnitOfWork unit_of_work)
        {
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.employee_entity_repository = Guard.IsNotNull(employee_entity_repository, "employee_entity_repository");

        }

        private readonly IEntityRepository<AllocatableResourcesTableView> employee_entity_repository;
        private readonly IUnitOfWork unit_of_work;
        private AllocatableResourcesTableView find_employee_table_view;
    }
}

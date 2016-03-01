using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.ThinClient.Query.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.ConfirmResourcesAllocation.eventHandlers
{
    public class AddConfirmResourceAllocationEditorViewWhenEmployeeCreated :IEventSubscriber<EmployeeCreatedEvent>
    {
        public void handle(EmployeeCreatedEvent the_event_to_handle)
        {
                create_entity(the_event_to_handle)
               .add_to_repository()
               .commit();
        }

        private AddConfirmResourceAllocationEditorViewWhenEmployeeCreated create_entity(EmployeeCreatedEvent the_event_to_handle)
        {
            Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");

            confirm_resource_allocation_editor_view = new ConfirmResourceAllocationEditorView
             {
                 employee_id = the_event_to_handle.employee_id,
                 employee_reference = the_event_to_handle.employee_reference,
                 name = the_event_to_handle.forename + " " + the_event_to_handle.surname
             };
            return this;
        }

        private AddConfirmResourceAllocationEditorViewWhenEmployeeCreated add_to_repository()
        {
            Guard.IsNotNull(confirm_resource_allocation_editor_view, "find_employee_table_view");

            employee_entity_repository.add(confirm_resource_allocation_editor_view);
            return this;
        }

        private void commit()
        {
           unit_of_work.Commit();
        }

        public AddConfirmResourceAllocationEditorViewWhenEmployeeCreated (IEntityRepository<ConfirmResourceAllocationEditorView> employee_entity_repository
                                             , IUnitOfWork unit_of_work)
        {
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.employee_entity_repository = Guard.IsNotNull(employee_entity_repository, "employee_entity_repository");

        }

        private readonly IEntityRepository<ConfirmResourceAllocationEditorView> employee_entity_repository;
        private readonly IUnitOfWork unit_of_work;
        private ConfirmResourceAllocationEditorView confirm_resource_allocation_editor_view;
    }
}

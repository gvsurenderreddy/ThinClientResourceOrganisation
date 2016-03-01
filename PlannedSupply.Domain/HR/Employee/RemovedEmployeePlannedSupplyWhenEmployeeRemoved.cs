using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.CodeStrutures.Creational;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.HR.Employee
{
    public class RemoveEmployeePlannedSupplyWhenEmployeeRemoved : IEventSubscriber<EmployeeRemovedEvent>
    {
        public void handle(EmployeeRemovedEvent the_event_to_handle)
        {
            set_event(the_event_to_handle)
                .find_the_planned_supply_employee()
                .find_resources_related_to_employee()
                .unallocate_related_resources()
                .remove_the_employee()
                .commit();
        }

        private RemoveEmployeePlannedSupplyWhenEmployeeRemoved set_event(EmployeeRemovedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");

            return this;
        }

        private RemoveEmployeePlannedSupplyWhenEmployeeRemoved find_the_planned_supply_employee()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");

            planned_supply_employee = employee_plannedsupply_repository
                                                            .Entities
                                                            .Single(e => e.employee_id == event_to_handle.employee_id);

            return this;
        }

        private RemoveEmployeePlannedSupplyWhenEmployeeRemoved find_resources_related_to_employee()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");


            related_resource_allocations =
                operations_calendar_repository
                    .Entities
                    .SelectMany(opc => opc.ShiftCalendars
                                            .SelectMany(sc => sc.ShiftCalendarPatterns
                                                                .SelectMany(scp => scp.ResourceAllocations
                                                                .Where(ra => ra.employee.employee_id == event_to_handle.employee_id)
                                                                .Select(ra => new ResourceAllocationIdentity()
                                                                {
                                                                    operations_calendar_id = opc.id,
                                                                    shift_calendar_id = sc.id,
                                                                    shift_calendar_pattern_id = scp.id,
                                                                    resource_allocation_id = ra.id
                                                                })))).ToList();


            return this;
        }

        private RemoveEmployeePlannedSupplyWhenEmployeeRemoved unallocate_related_resources()
        {
            Guard.IsNotNull(related_resource_allocations, "related_resource_allocations");

            related_resource_allocations.Do(ra => remove_resource_allocation_factory.create().execute(ra));

            return this;
        }

        private RemoveEmployeePlannedSupplyWhenEmployeeRemoved remove_the_employee()
        {
            Guard.IsNotNull(planned_supply_employee, "planned_supply_employee");

            employee_plannedsupply_repository.remove(planned_supply_employee);

            return this;
        }

        private void commit()
        {
            unit_of_work.Commit();
        }

        public RemoveEmployeePlannedSupplyWhenEmployeeRemoved(IEntityRepository<EmployeePlannedSupply> the_employee_plannedsupply_repository,
                                                                IEntityRepository<OperationalCalendar> the_operations_calendar_repository,
                                                                IFactory<RemoveResourceAllocation> the_remove_resource_allocation_factory,
                                                                IUnitOfWork the_unit_of_work)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            employee_plannedsupply_repository = Guard.IsNotNull(the_employee_plannedsupply_repository, "the_employee_plannedsupply_repository ");
            remove_resource_allocation_factory = Guard.IsNotNull(the_remove_resource_allocation_factory, "the_remove_resource_allocation");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly IFactory<RemoveResourceAllocation> remove_resource_allocation_factory;
        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly IEntityRepository<EmployeePlannedSupply> employee_plannedsupply_repository;
        private readonly IUnitOfWork unit_of_work;
        private IEnumerable<ResourceAllocationIdentity> related_resource_allocations;
        private EmployeePlannedSupply planned_supply_employee;
        private EmployeeRemovedEvent event_to_handle;

    }
}

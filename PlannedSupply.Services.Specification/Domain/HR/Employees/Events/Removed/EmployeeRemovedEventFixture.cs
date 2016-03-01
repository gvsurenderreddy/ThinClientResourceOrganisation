using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.HR.Employees.Events.Removed
{
    public class EmployeeRemovedEventFixture
    {
        public EmployeeRemovedEvent simulate_event()
        {
            var planned_employee = seed_a_fairly_complex_relationship_for_an_employee();

            return new EmployeeRemovedEvent
            {
                employee_id = planned_employee.employee_id,
            };
        }

        private EmployeePlannedSupply seed_a_fairly_complex_relationship_for_an_employee()
        {

            #region"exhaustive seed"

            var planned_employee = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee);

            var resource_allocation = new ResourceAllocationBuilder()
                                            .employee(planned_employee)
                                            .entity;


            var pattern = shift_calendar_pattern_helper.add()
                                                        .add_resouce_allocation(resource_allocation)
                                                        .number_of_resources(5)
                                                        .pattern_name("a pattern")
                                                        .priority(1)
                                                        .entity;

            var shift_calendar = shift_calendar_helper
                                    .add()
                                    .add_shift_calendar_pattern(pattern)
                                    .calendar_name("some calendar")
                                    .entity;

            operations_calendar_helper
                .add()
                .add_shift_calendar(shift_calendar)
                .calendar_name("some_operation");


            var resource_allocation_b = new ResourceAllocationBuilder()
                                            .employee(planned_employee)
                                            .entity;


            var pattern_b = shift_calendar_pattern_helper.add()
                                                        .add_resouce_allocation(resource_allocation_b)
                                                        .number_of_resources(5)
                                                        .pattern_name("a pattern")
                                                        .priority(1)
                                                        .entity;



            var shift_calendar_b = shift_calendar_helper
                                    .add()
                                    .add_shift_calendar_pattern(pattern_b)
                                    .calendar_name("some calendar")
                                    .entity;



            var resource_allocation_x = new ResourceAllocationBuilder()
                                            .employee(planned_employee)
                                            .entity;


            var pattern_x = shift_calendar_pattern_helper.add()
                                                        .add_resouce_allocation(resource_allocation_x)
                                                        .number_of_resources(5)
                                                        .pattern_name("a pattern")
                                                        .priority(1)
                                                        .entity;

            var shift_calendar_x = shift_calendar_helper
                                    .add()
                                    .add_shift_calendar_pattern(pattern_x)
                                    .calendar_name("some calendar")
                                    .entity;


            operations_calendar_helper
                .add()
                .add_shift_calendar(shift_calendar_x)
                .add_shift_calendar(shift_calendar_b)
                .calendar_name("some_operation_b");

            #endregion

            return planned_employee;
        }

        public IEnumerable<EmployeePlannedSupply> planning_employees { get { return employee_planned_supply_repository.Entities; } }

        public IEnumerable<OperationalCalendar> operational_calendars { get { return operations_calendar_repository.Entities; } }

        public RemoveEmployeePlannedSupplyWhenEmployeeRemoved event_handler { get; private set; }
        
        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public EmployeeRemovedEventFixture(ShiftCalendarPatternHelper the_shift_calendar_pattern_helper,
                                                ShiftCalendarHelper the_shift_calendar_helper,
                                                OperationsCalendarHelper the_operations_calendar_helper,
                                                IEntityRepository<EmployeePlannedSupply> the_employee_planned_supply_repository,
                                                IEntityRepository<OperationalCalendar> the_operations_calendar_repository)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            employee_planned_supply_repository = Guard.IsNotNull(the_employee_planned_supply_repository, "the_employee_planned_supply_repository");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            operations_calendar_helper = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper");

            event_handler = DependencyResolver.resolve<RemoveEmployeePlannedSupplyWhenEmployeeRemoved>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
           
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly IEntityRepository<EmployeePlannedSupply> employee_planned_supply_repository;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly OperationsCalendarHelper operations_calendar_helper;

        private readonly FakeUnitOfWork unit_of_work;
        private int new_event_id = 0;
    }
}

using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.post;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Create
{
    public class AllocateResourceFixture
    {
        public AllocateEmployeeToPatternRequest create_request()
        {
            var planned_employee = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee);

            return new AllocateEmployeeToPatternRequest
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern_a.id,
                employee_id = planned_employee.employee_id
            };
        }

        public AllocateEmployeeToPatternRequest create_request_with_employee_in_different_pattern()
        {
            var planned_employee1 = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee1);

            var planned_employee2 = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee1);
            employee_planned_supply_repository.add(planned_employee2);

            var resource_allocation1 = new ResourceAllocationBuilder()
                                            .employee(planned_employee1)
                                            .entity;

            var resource_allocation2= new ResourceAllocationBuilder()
                                            .employee(planned_employee2)
                                            .entity;

            shift_calendar_pattern_a.ResourceAllocations.Add(resource_allocation1);
            shift_calendar_pattern_b.ResourceAllocations.Add(resource_allocation2);


            return new AllocateEmployeeToPatternRequest
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern_a.id,
                employee_id = resource_allocation2.employee.employee_id
            };
            
        }

        public AllocateEmployeeToPatternRequest add_resource_to_different_calendar()
        {
            var planned_employee1 = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee1);

            var planned_employee2 = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee1);
            employee_planned_supply_repository.add(planned_employee2);

            var resource_allocation1 = new ResourceAllocationBuilder()
                                            .employee(planned_employee1)
                                            .entity;

            var resource_allocation2 = new ResourceAllocationBuilder()
                                            .employee(planned_employee2)
                                            .entity;

            shift_calendar_pattern_c.ResourceAllocations.Add(resource_allocation1);
            shift_calendar_pattern_c.ResourceAllocations.Add(resource_allocation2);

            return new AllocateEmployeeToPatternRequest
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern_a.id,
                employee_id = resource_allocation2.employee.employee_id
            };

        }

        public void allocate_employee_to_a_pattern()
        {
            var planned_employee1 = new EmployeePlannedSupply()
            {
                employee_id = ++new_event_id,
                id = ++new_event_id
            };
            employee_planned_supply_repository.add(planned_employee1);

            var resource_allocation1 = new ResourceAllocationBuilder()
                                            .employee(planned_employee1)
                                            .entity;

            shift_calendar_pattern_a.ResourceAllocations.Add(resource_allocation1);

        }

        public AllocateEmployeeToPatternRequest create_Allocate_Employee_To_Pattern_Request()
        {
            return new AllocateEmployeeToPatternRequest
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern_a.id,
                employee_id = shift_calendar_pattern_a.ResourceAllocations.First().employee.employee_id
            };

        }
        public AllocateResourceFixture(IEntityRepository<EmployeePlannedSupply> the_employee_planned_supply_repository,
                                        IEntityRepository<OperationalCalendar> the_operations_calendar_repository
                                        ,IAllocateEmployeeToPatternRequestHandler the_command
                                        ,ShiftCalendarPatternHelper the_shift_calendar_pattern_helper
                                        ,ShiftCalendarHelper the_shift_calendar_helper
                                        ,OperationsCalendarHelper the_operations_calendar_helper
                                        )
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            employee_planned_supply_repository = Guard.IsNotNull(the_employee_planned_supply_repository, "the_employee_planned_supply_repository");
            command = Guard.IsNotNull(the_command, "the_command");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");


            shift_calendar_pattern_a = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
               .add()
               .entity
               ;

            shift_calendar_pattern_b = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
                .add()
                .entity
                ;

            shift_calendar_pattern_c = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
                .add()
                .entity
                ;

             shift_calendar = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper")
                                   .add()
                                   .add_shift_calendar_pattern(shift_calendar_pattern_a)
                                   .add_shift_calendar_pattern(shift_calendar_pattern_b)
                                   .calendar_name("some calendar")
                                   .entity;

             shift_calendar_b = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper")
                                    .add()
                                    .add_shift_calendar_pattern(shift_calendar_pattern_c)
                                    .calendar_name("some new calendar")
                                    .entity;

             operations_calendar = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper")
                .add()
                .add_shift_calendar(shift_calendar)
                .add_shift_calendar(shift_calendar_b)
                .calendar_name("some_operation").entity;
        }

        public IEnumerable<EmployeePlannedSupply> planning_employees { get { return employee_planned_supply_repository.Entities; } }
        public IEnumerable<OperationalCalendar> operational_calendars { get { return operations_calendar_repository.Entities; } }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly IEntityRepository<EmployeePlannedSupply> employee_planned_supply_repository;
        public readonly IAllocateEmployeeToPatternRequestHandler command;

        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;

        public readonly OperationsCalendars.OperationalCalendar operations_calendar;
        private readonly ShiftCalendars.ShiftCalendar shift_calendar;
        private readonly ShiftCalendars.ShiftCalendar shift_calendar_b;

        public ShiftCalendarPattern shift_calendar_pattern_a;
        public ShiftCalendarPattern shift_calendar_pattern_b;
        public ShiftCalendarPattern shift_calendar_pattern_c;
        private int new_event_id = 0;
    }
}

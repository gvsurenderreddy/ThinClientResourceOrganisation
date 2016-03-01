using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.get;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.post;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Remove
{
    public class PlannedSupplyRemovedEventFixture
    {

        public RemoveResourceAllocationFromPatternRequest add_resource()
        {
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

            var operations_calendar = operations_calendar_helper
                .add()
                .add_shift_calendar(shift_calendar)
                .calendar_name("some_operation").entity;


            return get_remove_request.execute(
                            new ResourceAllocationIdentity
                            {
                                resource_allocation_id = resource_allocation.id,
                                operations_calendar_id = operations_calendar.id,
                                shift_calendar_id = shift_calendar.id,
                                shift_calendar_pattern_id = pattern.id,
                            }
                        )
                        .result;
        }


        public PlannedSupplyRemovedEventFixture( ShiftCalendarPatternHelper the_shift_calendar_pattern_helper
                                               , ShiftCalendarHelper the_shift_calendar_helper
                                               , OperationsCalendarHelper the_operations_calendar_helper
                                               , IEntityRepository<EmployeePlannedSupply> the_employee_planned_supply_repository
                                               , IRemoveResourceAllocationFromPatternRequestHandler the_query
                                               , IEntityRepository<OperationalCalendar> the_operations_calendar_repository 
                                               , IGetRemoveResourceAllocationFromPatternRequestHandler the_get_remove_request)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            employee_planned_supply_repository = Guard.IsNotNull(the_employee_planned_supply_repository, "the_employee_planned_supply_repository");
            _query = Guard.IsNotNull(the_query, "the_query");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            operations_calendar_helper = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper");
            get_remove_request = Guard.IsNotNull(the_get_remove_request, "the_get_remove_request");

        }

        public IEnumerable<EmployeePlannedSupply> planning_employees { get { return employee_planned_supply_repository.Entities; } }
        public IEnumerable<OperationalCalendar> operational_calendars { get { return operations_calendar_repository.Entities; } }


        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly IEntityRepository<EmployeePlannedSupply> employee_planned_supply_repository;
        public IRemoveResourceAllocationFromPatternRequestHandler _query;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly OperationsCalendarHelper operations_calendar_helper;
        private readonly IGetRemoveResourceAllocationFromPatternRequestHandler get_remove_request;
        private int new_event_id = 0;
    }
}

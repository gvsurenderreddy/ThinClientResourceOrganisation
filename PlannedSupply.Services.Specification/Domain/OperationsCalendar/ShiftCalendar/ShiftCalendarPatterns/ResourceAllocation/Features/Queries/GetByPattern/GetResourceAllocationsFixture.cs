using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByPattern
{
    public class GetResourceAllocationsFixture
    {
        public ResourceAllocationBuilder add_resource_allocation()
        {
            var resource_allocation_builder = new ResourceAllocationBuilder();
            var resource_allocation = resource_allocation_builder.entity;

            _shift_calendar_pattern
                .ResourceAllocations
                .Add(resource_allocation)
                ;

            return resource_allocation_builder;
        }

        public void execute_query()
        {
            response = _query.execute(_request);
        }

        public GetResourceAllocationsFixture(   ShiftCalendarPatternHelper the_shift_calendar_pattern_helper,
                                                ShiftCalendarHelper the_shift_calendar_helper,
                                                OperationsCalendarHelper the_operations_calendar_helper,
                                                IGetResourceAllocationsByShiftCalendarPattern the_query)
        {
            _shift_calendar_pattern = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
                                    .add()
                                    .entity
                                    ;

            _shift_calendar = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper")
                                    .add()
                                    .add_shift_calendar_pattern(_shift_calendar_pattern)
                                    .entity
                                    ;

            _operational_calendar = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper")
                                    .add()
                                    .add_shift_calendar(_shift_calendar)
                                    .entity
                                    ;

            _request = new ShiftCalendarPatternIdentity
            {
                operations_calendar_id = _operational_calendar.id,
                shift_calendar_id = _shift_calendar.id,
                shift_calendar_pattern_id = _shift_calendar_pattern.id
            };

            _query = Guard.IsNotNull(the_query, "the_query");
        }

        public ShiftCalendarPatternIdentity _request { get; private set; }
        public GetResourceAllocationsByShiftCalendarPatternResponse response { get; private set; }
        
        public OperationalCalendar _operational_calendar;
        public PlannedSupply.ShiftCalendars.ShiftCalendar _shift_calendar;
        public ShiftCalendarPattern _shift_calendar_pattern;

        private readonly IGetResourceAllocationsByShiftCalendarPattern _query;
    }
}

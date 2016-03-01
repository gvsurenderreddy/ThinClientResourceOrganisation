using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Queries.GetByCalendar
{
    public class GetResourceAllocationsFixture
    {
        public ResourceAllocationBuilder add_allocation_to_pattern_a()
        {
            var resource_allocation_builder = new ResourceAllocationBuilder();
            var resource_allocation = resource_allocation_builder.entity;

            _shift_calendar_pattern_a
                .ResourceAllocations
                .Add(resource_allocation)
                ;

            return resource_allocation_builder;
        }

        public ResourceAllocationBuilder add_allocation_to_pattern_b()
        {
            var resource_allocation_builder = new ResourceAllocationBuilder();
            var resource_allocation = resource_allocation_builder.entity;

            _shift_calendar_pattern_b
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
                                                IGetResourceAllocationsByShiftCalendar the_query)
        {
            _shift_calendar_pattern_a = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
                .add()
                .entity
                ;

            _shift_calendar_pattern_b = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper")
                .add()
                .entity
                ;

            _shift_calendar = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper")
                .add()
                .add_shift_calendar_pattern(_shift_calendar_pattern_a)
                .add_shift_calendar_pattern(_shift_calendar_pattern_b)
                .entity
                ;

            _operational_calendar = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper")
                .add()
                .add_shift_calendar(_shift_calendar)
                .entity
                ;

            _request = new ShiftCalendarIdentity
            {
                operations_calendar_id = _operational_calendar.id,
                shift_calendar_id = _shift_calendar.id
            };

            _query = Guard.IsNotNull(the_query, "the_query");
        }

        public ShiftCalendarIdentity _request { get; private set; }
        public GetResourceAllocationsByShiftCalendarResponse response { get; private set; }
        
        public OperationalCalendar _operational_calendar;
        public PlannedSupply.ShiftCalendars.ShiftCalendar _shift_calendar;
        public ShiftCalendarPattern _shift_calendar_pattern_a;
        public ShiftCalendarPattern _shift_calendar_pattern_b;

        private readonly IGetResourceAllocationsByShiftCalendar _query;
    }
}

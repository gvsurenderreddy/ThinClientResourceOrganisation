using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange
{
    public class GetOperationsCalendarAggregateOverRange : IGetOperationsCalendarAggregateOverRange
    {
        public Response<OperationsCalendarAggregateOverRange> execute(GetOperationsCalendarAggregateOverRangeRequest request)
        {
            var operational_calendar = operations_calendar_query_repository
                                                                        .Entities
                                                                        .Single(oc => oc.id == request.operations_calendar_id);

            int _NUM_OF_DAYS_;
            ShiftCalendarRange _RANGE_RETURNED_;

            switch (request.range_type)
            {
                case ShiftCalendarRange.Week:
                    _RANGE_RETURNED_ = ShiftCalendarRange.Week;
                    _NUM_OF_DAYS_ = 7;
                    break;
                case ShiftCalendarRange.FourWeek:
                    _RANGE_RETURNED_ = ShiftCalendarRange.FourWeek;
                    _NUM_OF_DAYS_ = 28;
                    break;
                default:
                    _RANGE_RETURNED_ = ShiftCalendarRange.Week;
                    _NUM_OF_DAYS_ = 7;
                    break;
            }

            //fetch with 1 day padding before and after main dataset)
            var _START_DATE_ = request.start_date.AddDays(-1).Date;
            var _END_DATE_ = request.start_date.AddDays(_NUM_OF_DAYS_).Date;

            return new Response<OperationsCalendarAggregateOverRange>
            {
                result = new OperationsCalendarAggregateOverRange
                {
                    range_returned = _RANGE_RETURNED_,
                    start_date = request.start_date,
                    operations_calendar_id = request.operations_calendar_id,
                    calendar_name = operational_calendar.calendar_name,
                    all_shift_calendars_details = operational_calendar
                                                                    .ShiftCalendars
                                                                    .Select(sc => new ShiftCalendarAggregateOverRange
                                                                    {
                                                                        patterns_range_returned = request.range_type,
                                                                        patterns_start_date = request.start_date,
                                                                        operations_calendar_id = operational_calendar.id,
                                                                        shift_calendar_id = sc.id,
                                                                        calendar_name = sc.calendar_name,
                                                                        shift_calendar_patterns = sc
                                                                                                            .ShiftCalendarPatterns
                                                                                                            .OrderBy(a => a.priority)
                                                                                                            .AsEnumerable()
                                                                                                            .Select(p => new ShiftCalendarPatternDetails
                                                                                                            {
                                                                                                                operations_calendar_id = operational_calendar.id,
                                                                                                                shift_calendar_id = sc.id,
                                                                                                                shift_calendar_pattern_id = p.id,
                                                                                                                shift_calendar_pattern_name = p.name,
                                                                                                                number_of_resources = p.number_of_resources,
                                                                                                                resource_allocation_summary = p.ResourceAllocations.Count(),
                                                                                                                time_allocation_occurrences = p.TimeAllocationOccurrences
                                                                                                                                                .AsEnumerable()
                                                                                                                                                .Where(x => x.start_date >= _START_DATE_ && x.start_date <= _END_DATE_)
                                                                                                                                                .OrderBy(o => o.start_date)
                                                                                                                                                .Select(z => new TimeAllocationOccurrenceDetails()
                                                                                                                                                {
                                                                                                                                                    start_date = z.start_date,
                                                                                                                                                    duration_in_seconds = z.time_allocation.duration_in_seconds,
                                                                                                                                                    colour = z.time_allocation.colour,
                                                                                                                                                    start_time_in_seconds_from_midnight = z.time_allocation.start_time_in_seconds_from_midnight,
                                                                                                                                                    title = z.time_allocation.title,
                                                                                                                                                    time_allocation_kind = TimeAllocationKind.SHIFT
                                                                                                                                                })
                                                                                                            })
                                                                    })
                }
            };
        }

        public GetOperationsCalendarAggregateOverRange(IQueryRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_query_repository)
        {
            operations_calendar_query_repository = Guard.IsNotNull(the_operations_calendar_query_repository, "the_operations_calendar_query_repository");
        }

        private readonly IQueryRepository<OperationsCalendars.OperationalCalendar> operations_calendar_query_repository;
    }
}
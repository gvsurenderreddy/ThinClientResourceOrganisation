
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.GetAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetAll
{
    public class GetAllShiftBreaksFixture
    {
        public ShiftBreakDetails seed_request_break(int offset, int duration, bool is_paid)
        {
            var shift_break = new TimeAllocationBreak()
            {
                id = -111,
                duration_in_seconds = duration,
                is_paid = is_paid,
                offset_from_start_time_in_seconds = offset
            };

            var occurrence = get_shift_occurrence.execute(request);

            occurrence.time_allocation.TimeAllocationBreaks.Add(shift_break);

            return new ShiftBreakDetails
            {
                 shift_break_id = shift_break.id,
                 duration = shift_break.duration_in_seconds.to_duration_request(),
                 offset_from_start_time = shift_break.offset_from_start_time_in_seconds.to_duration_request(),
                 is_paid = shift_break.is_paid
            };
        }

        public ShiftOccurrenceIdentity request { get; private set; }
        public GetAllShiftBreaksResponse response { get; private set; }

        public void execute_query()
        {
            response = query.execute(request);
        }


        public GetAllShiftBreaksFixture(IGetAllShiftBreaks the_query, 
                                        IRequestHelper<ShiftOccurrenceIdentity> the_request_builder,
                                        GetOccurrence the_get_shift_occurrence) 
        {
            query = Guard.IsNotNull(the_query, "the_query");
            request = Guard.IsNotNull(the_request_builder, "the_request_builder").given_a_valid_request( );
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
        }


        private readonly IGetAllShiftBreaks query;
        private readonly GetOccurrence get_shift_occurrence;
    }
}
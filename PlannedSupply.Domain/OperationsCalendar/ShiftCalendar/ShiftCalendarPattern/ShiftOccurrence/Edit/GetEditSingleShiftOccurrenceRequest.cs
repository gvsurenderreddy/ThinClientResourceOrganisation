using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit
{
    public class GetEditSingleShiftOccurrenceRequest : IGetEditSingleShiftOccurrenceRequest
    {
        public Response<EditSingleShiftOccurrenceRequest> execute(ShiftOccurrenceIdentity request)
        {
            var shift_occurrence = get_shift_occurrence.execute(request);
            var time_allocation = shift_occurrence.time_allocation;

            return new Response<EditSingleShiftOccurrenceRequest>()
           {
               result = new EditSingleShiftOccurrenceRequest()
               {
                   operations_calendar_id = request.operations_calendar_id,
                   shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                   shift_calendar_id = request.shift_calendar_id,
                   shift_occurrence_id = request.shift_occurrence_id,
                   start_date = shift_occurrence.start_date.FormatForReport(),
                   shift_title = time_allocation.title,
                   colour = time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                   start_time = time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                   duration = time_allocation.duration_in_seconds.to_duration_request()
               },

               messages = null,
               has_errors = false
           };
        }

        public GetEditSingleShiftOccurrenceRequest(GetOccurrence the_get_shift_occurrence)
        {
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
        }

        private readonly GetOccurrence get_shift_occurrence;

    }
}
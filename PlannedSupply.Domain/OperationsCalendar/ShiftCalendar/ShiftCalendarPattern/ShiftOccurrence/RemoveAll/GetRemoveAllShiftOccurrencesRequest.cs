using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public class GetRemoveAllShiftOccurrencesRequest :IGetRemoveAllShiftOccurrencesRequest
    {
        public Response<RemoveAllShiftOccurrencesRequest> execute(ShiftOccurrenceIdentity request)
        {
            var shift_occurrence = get_shift_occurrence
                                        .execute(request)
                                        ;
            var time_allocation = shift_occurrence
                                        .time_allocation
                                        ;

            List<ShiftCalendarOccurencesCountDetails> shift_calendar_name_and_number_of_occurrences = get_occurrences_from_all_shift_calendar
                                                                                                            .execute(request)
                                                                                                            ;

           return new Response<RemoveAllShiftOccurrencesRequest>()
           {
               result = new RemoveAllShiftOccurrencesRequest()
               {
                   operations_calendar_id = request.operations_calendar_id,
                   shift_calendar_id = request.shift_calendar_id,
                   shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                   shift_occurrence_id = shift_occurrence.id,
                   shift_calendar_affected = shift_calendar_name_and_number_of_occurrences,
                   colour = time_allocation.colour.rgb_colour_format(),
                   duration = time_allocation.duration_in_seconds.to_duration_request().to_domain_format_string(),
                   start_time = time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().to_domain_string(),
                   title = time_allocation.title
               },
                messages = null,
                has_errors = false
           };
        }

        public GetRemoveAllShiftOccurrencesRequest(GetOccurrence the_get_shift_occurrence,
                                                  GetShiftOccurrencesFromAllShiftCalendars the_get_occurrences_from_all_shift_calendar
                                                 )
        {
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            get_occurrences_from_all_shift_calendar = Guard.IsNotNull(the_get_occurrences_from_all_shift_calendar,
                                                                      "the_get_occurrences_from_all_shift_calendar"
                                                                     );
        }

        private readonly GetOccurrence get_shift_occurrence;
        private readonly GetShiftOccurrencesFromAllShiftCalendars get_occurrences_from_all_shift_calendar;
    }
}
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll
{
    public class GetEditAllShiftOccurrencesRequest
                    : IGetEditAllShiftOccurrencesRequest
    {
        public Response<EditAllShiftOccurrencesRequest> execute(ShiftOccurrenceIdentity the_request)
        {
            var shift_occurrence = get_shift_occurrence
                                        .execute(the_request)
                                        ;
            var time_allocation = shift_occurrence
                                        .time_allocation
                                        ;

            List<ShiftCalendarOccurencesCountDetails> shift_calendar_name_and_number_of_occurrences = get_occurrences_from_all_shift_calendar
                                                                                                            .execute(the_request)
                                                                                                            ;

            return new Response<EditAllShiftOccurrencesRequest>
                            {
                                result = new EditAllShiftOccurrencesRequest
                                                {
                                                    operations_calendar_id = the_request.operations_calendar_id,
                                                    shift_calendar_id = the_request.shift_calendar_id,
                                                    shift_calendar_pattern_id = the_request.shift_calendar_pattern_id,
                                                    shift_occurrence_id = the_request.shift_occurrence_id,
                                                    affected_shift_calendars = shift_calendar_name_and_number_of_occurrences,
                                                    shift_title = time_allocation.title,
                                                    colour = time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                                                    start_time = time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                                                    duration = time_allocation.duration_in_seconds.to_duration_request()
                                                },
                                messages = null,
                                has_errors = false
                            };
        }

        public GetEditAllShiftOccurrencesRequest(GetOccurrence the_get_shift_occurrence,
                                                  GetShiftOccurrencesFromAllShiftCalendars the_get_occurrences_from_all_shift_calendar)
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
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetAllDetails
{
    public class GetAllOccurrencesDetails : IGetAllOccurrencesDetails
    {
        public Response<AllOccurrencesDetails> execute(ShiftOccurrenceIdentity request)
        {

            var operational_calendar = operational_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);

            var shift_calendar = operational_calendar.ShiftCalendars.Single(sc => sc.id == request.shift_calendar_id);

            var shift_calendar_pattern = shift_calendar.ShiftCalendarPatterns.Single(sc => sc.id == request.shift_calendar_pattern_id);

            var shift_occurrence = shift_calendar_pattern.TimeAllocationOccurrences.Single(sc => sc.id == request.shift_occurrence_id);

            var shift_calendar_name_and_number_of_occurrences = get_occurrences_from_all_shift_calendar.execute(request);


            return new Response<AllOccurrencesDetails>()
            {
                result = new AllOccurrencesDetails
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = shift_calendar.id,
                    shift_calendar_pattern_id = shift_calendar_pattern.id,
                    shift_occurrence_id = shift_occurrence.id,
                    affected_shift_calendars = shift_calendar_name_and_number_of_occurrences,
                    colour = shift_occurrence.time_allocation.colour.rgb_colour_format(),
                    duration = shift_occurrence.time_allocation.duration_in_seconds.to_duration_request().to_domain_format_string(),
                    start_time = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().to_domain_string(),
                    shift_title = shift_occurrence.time_allocation.title
                },
                messages = null,
                has_errors = false
            };
        }

        public GetAllOccurrencesDetails(IQueryRepository<OperationsCalendars.OperationalCalendar> the_operational_calendar_repository,
                                        GetShiftOccurrencesFromAllShiftCalendars the_get_occurrences_from_all_shift_calendar)
        {
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");

            get_occurrences_from_all_shift_calendar = Guard.IsNotNull(the_get_occurrences_from_all_shift_calendar, "the_get_occurrences_from_all_shift_calendar");
        }

        private readonly IQueryRepository<OperationsCalendars.OperationalCalendar> operational_calendar_repository;
        private readonly GetShiftOccurrencesFromAllShiftCalendars get_occurrences_from_all_shift_calendar;

    }
}
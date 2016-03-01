using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove
{
    public class GetRemoveShiftOccurrenceRequest : IGetRemoveShiftOccurrenceRequest
    {
        public Response<RemoveShiftOccurrenceRequest> execute(ShiftOccurrenceIdentity request)
        {
            var operational_calendar = operational_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);

            var shift_calendar = operational_calendar.ShiftCalendars.Single(sc => sc.id == request.shift_calendar_id);

            var shift_calendar_pattern = shift_calendar.ShiftCalendarPatterns.Single(sc => sc.id == request.shift_calendar_pattern_id);

            var shift_occurrence = shift_calendar_pattern.TimeAllocationOccurrences.Single(sc => sc.id == request.shift_occurrence_id);

            return new Response<RemoveShiftOccurrenceRequest>
            {
                result = new RemoveShiftOccurrenceRequest
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_calendar_id = shift_calendar.id,
                    shift_calendar_pattern_id = shift_calendar_pattern.id,
                    shift_occurrence_id = shift_occurrence.id,
                    start_date = shift_occurrence.start_date.FormatForReport(),
                    //IMPROVE: THESE presentation type formatting need to be done in the presentation library
                    colour = shift_occurrence.time_allocation.colour.rgb_colour_format(),
                    duration = shift_occurrence.time_allocation.duration_in_seconds.to_duration_request().to_domain_format_string(),
                    start_time = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().to_domain_string(),
                    title = shift_occurrence.time_allocation.title
                },
                messages = null,
                has_errors = false
            };
        }


        public GetRemoveShiftOccurrenceRequest(IEntityRepository<OperationsCalendars.OperationalCalendar> the_operational_calendar_repository)
        {
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
        }

        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> operational_calendar_repository;
    }
}

using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New
{
    public class GetNewShiftOccurrenceRequest
                        : IGetNewShiftOccurrenceRequest
    {
        public NewShiftOccurrenceRequest execute(TimeBlockIdentity request)
        {
            return new NewShiftOccurrenceRequest()
            {
                start_date = request.start_date,
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_title = string.Empty,
                colour = new RGBColourRequest() { R = 255, G = 255, B = 255 },//White: our default colour
                start_time = new TimeRequest()
                {
                    hours = string.Empty,
                    minutes = string.Empty

                },
                duration = new DurationRequest()
                {
                    hours = string.Empty,
                    minutes = string.Empty
                }

            };
        }
    }
}
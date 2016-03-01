using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New
{
    public class NewShiftCalendarPatternRequestHelper
                        : IRequestHelper<NewShiftCalendarPatternRequest>
    {
        public NewShiftCalendarPatternRequest given_a_valid_request()
        {
            var shift_calendar_pattern_identity = shift_calendar_pattern_identity_helper.get_identity();

            return new NewShiftCalendarPatternRequest
            {
                operations_calendar_id = shift_calendar_pattern_identity.operations_calendar_id,
                shift_calendar_id = shift_calendar_pattern_identity.shift_calendar_id,
                pattern_name = "Shift calendar pattern B",
                number_of_resources = "1"
            };
        }

        public NewShiftCalendarPatternRequestHelper()
        {
            shift_calendar_pattern_identity_helper = new ShiftCalendarPatternIdentityHelper();
        }

        private ShiftCalendarPatternIdentityHelper shift_calendar_pattern_identity_helper;
    }
}
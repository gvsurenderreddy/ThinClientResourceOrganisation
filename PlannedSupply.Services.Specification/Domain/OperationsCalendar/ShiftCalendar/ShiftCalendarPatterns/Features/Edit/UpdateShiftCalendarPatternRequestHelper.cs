using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit
{
    public class UpdateShiftCalendarPatternRequestHelper
                        : IRequestHelper<UpdateShiftCalendarPatternRequest>
    {
        public UpdateShiftCalendarPatternRequest given_a_valid_request()
        {
            var shift_calendar_pattern_identity = shift_calendar_pattern_identity_helper.get_identity();

            return new UpdateShiftCalendarPatternRequest
                            {
                                operations_calendar_id = shift_calendar_pattern_identity.operations_calendar_id,
                                shift_calendar_id = shift_calendar_pattern_identity.shift_calendar_id,
                                shift_calendar_pattern_id = shift_calendar_pattern_identity.shift_calendar_pattern_id,
                                pattern_name = "Shift calendar pattern A",
                                number_of_resources = "1"
                            };
        }

        public UpdateShiftCalendarPatternRequestHelper()
        {
            shift_calendar_pattern_identity_helper = new ShiftCalendarPatternIdentityHelper();
        }

        private ShiftCalendarPatternIdentityHelper shift_calendar_pattern_identity_helper;
    }
}
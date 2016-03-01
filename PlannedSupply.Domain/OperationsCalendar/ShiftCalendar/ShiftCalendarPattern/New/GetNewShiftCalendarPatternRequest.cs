using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New
{
    public class GetNewShiftCalendarPatternRequest
                        : IGetNewShiftCalendarPatternRequest
    {
        public NewShiftCalendarPatternRequest execute(ShiftCalendarPatternIdentity request)
        {
            return new NewShiftCalendarPatternRequest
                            {
                                operations_calendar_id = request.operations_calendar_id,
                                shift_calendar_id = request.shift_calendar_id,
                                pattern_name = string.Empty,
                                number_of_resources = string.Empty
                            };
        }
    }
}
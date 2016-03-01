using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New
{
    public class GetNewShiftCalendarRequest
                        : IGetNewShiftCalendarRequest
    {
        public NewShiftCalendarRequest execute(ShiftCalendarIdentity the_request )
        {
            return new NewShiftCalendarRequest
            {
                operations_calendar_id = the_request.operations_calendar_id,
                calendar_name = string.Empty
            };
        }
    }
}
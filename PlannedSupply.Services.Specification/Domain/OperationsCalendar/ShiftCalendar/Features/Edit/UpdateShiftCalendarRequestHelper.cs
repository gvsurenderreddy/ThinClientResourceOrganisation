using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit
{
    public class UpdateShiftCalendarRequestHelper
                        : IRequestHelper<UpdateShiftCalendarRequest>
    {
        public UpdateShiftCalendarRequest given_a_valid_request()
        {
            var shift_calendar_identity = shift_calendar_identity_helper.get_identity();

            return new UpdateShiftCalendarRequest
            {
                operations_calendar_id = shift_calendar_identity.operations_calendar_id,
                shift_calendar_id = shift_calendar_identity.shift_calendar_id,
                calendar_name = "Shift calendar A"
            };
        }

        public UpdateShiftCalendarRequestHelper()
        {
            shift_calendar_identity_helper = new ShiftCalendarIdentityHelper();
        }

        private ShiftCalendarIdentityHelper shift_calendar_identity_helper;
    }
}
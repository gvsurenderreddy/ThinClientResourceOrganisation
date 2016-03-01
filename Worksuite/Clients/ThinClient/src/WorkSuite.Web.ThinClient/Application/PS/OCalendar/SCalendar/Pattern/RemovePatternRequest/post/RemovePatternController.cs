using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.removePattern.post
{
    public class RemovePatternController
                        : Controller
    {
        public ActionResult SubmitRequest(ShiftCalendarPatternIdentity the_remove_shift_calendar_request)
        {
            var response = _remove_shift_calendar_pattern_command
                                .execute(the_remove_shift_calendar_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemovePatternController(IRemoveShiftCalendarPattern the_remove_shift_calendar_pattern_command)
        {
            _remove_shift_calendar_pattern_command = Guard.IsNotNull(the_remove_shift_calendar_pattern_command,
                                                                        "the_remove_shift_calendar_pattern_command"
                                                                    );
        }

        private readonly IRemoveShiftCalendarPattern _remove_shift_calendar_pattern_command;
    }
}
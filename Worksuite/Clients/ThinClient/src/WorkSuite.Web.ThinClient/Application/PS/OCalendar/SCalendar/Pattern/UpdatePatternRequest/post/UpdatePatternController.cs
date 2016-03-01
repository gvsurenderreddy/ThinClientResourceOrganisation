using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.updatePattern.post
{
    public class UpdatePatternController
                        : Controller
    {
        public ActionResult SubmitRequest(UpdateShiftCalendarPatternRequest the_update_shift_calendar_pattern_request)
        {
            UpdateShiftCalendarPatternResponse response = _update_shift_calendar_pattern
                                                                .execute(the_update_shift_calendar_pattern_request)
                                                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdatePatternController(IUpdateShiftCalendarPattern the_update_shift_calendar_pattern)
        {
            _update_shift_calendar_pattern = Guard.IsNotNull(the_update_shift_calendar_pattern,
                                                            "the_update_shift_calendar_pattern"
                                                            );
        }

        private IUpdateShiftCalendarPattern _update_shift_calendar_pattern;
    }
}
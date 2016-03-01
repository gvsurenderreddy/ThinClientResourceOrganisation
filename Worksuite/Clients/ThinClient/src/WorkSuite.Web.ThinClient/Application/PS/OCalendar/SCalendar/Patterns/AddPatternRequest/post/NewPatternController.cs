using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.newPattern.post
{
    public class NewPatternController
                        : Controller
    {
        public ActionResult SubmitRequest(NewShiftCalendarPatternRequest new_shift_calendar_pattern_request)
        {
            var response = _new_shift_calendar_pattern
                                .execute(new_shift_calendar_pattern_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public NewPatternController(INewShiftCalendarPattern the_new_shift_calendar_pattern)
        {
            _new_shift_calendar_pattern = Guard.IsNotNull(the_new_shift_calendar_pattern,
                                                            "the_new_shift_calendar_pattern"
                                                         );
        }

        private readonly INewShiftCalendarPattern _new_shift_calendar_pattern;
    }
}
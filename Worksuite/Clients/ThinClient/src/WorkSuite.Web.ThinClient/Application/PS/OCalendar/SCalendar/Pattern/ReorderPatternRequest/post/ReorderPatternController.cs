using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.reorderPattern.post
{
    public class ReorderPatternController : Controller
    {
        public ActionResult SubmitRequest(ReorderShiftCalendarPatternRequest the_reorder_request)
        {
            var response = reorder_shift_calendar_pattern.execute(the_reorder_request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ReorderPatternController(IReorderShiftCalendarPattern the_reorder_command)
        {
            reorder_shift_calendar_pattern = Guard.IsNotNull(the_reorder_command, "the_reorder_command");
        }

        private readonly IReorderShiftCalendarPattern reorder_shift_calendar_pattern;
    }
}
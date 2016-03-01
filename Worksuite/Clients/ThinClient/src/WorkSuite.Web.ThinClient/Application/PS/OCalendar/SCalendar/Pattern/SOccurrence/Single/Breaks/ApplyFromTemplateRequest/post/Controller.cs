using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Commands.ApplyFromTemplate
{
    /// <summary>
    /// The file name for this class has been named just controller.
    /// This is because VS & TFS do not allow a file path to exceed a certain count
    /// </summary>
    public class ApplyShiftBreaksFromBreakTemplateController : Controller
    {
        public ActionResult SubmitRequest(ApplyShiftBreaksFromBreakTemplateRequest new_shift_calendar_pattern_request)
        {
            var response = apply_command.execute(new_shift_calendar_pattern_request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ApplyShiftBreaksFromBreakTemplateController(IApplyShiftBreaksFromBreakTemplate the_apply_command)
        {
            apply_command = Guard.IsNotNull(the_apply_command, "the_apply_command");
        }

        private readonly IApplyShiftBreaksFromBreakTemplate apply_command;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Commands.ApplyFromTemplate
{
    /// <summary>
    /// The file name for this class has been named just controller.
    /// This is because VS & TFS do not allow a file path to exceed a certain count
    /// </summary>
    public class ApplyShiftBreaksFromBreakTemplateForAllOccurrencesController : Controller
    {
        public ActionResult SubmitRequest(ApplyShiftBreaksFromBreakTemplateRequest request)
        {
            var response = apply_command.execute(request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ApplyShiftBreaksFromBreakTemplateForAllOccurrencesController(IApplyShiftBreaksFromBreakTemplateForAllOccurrences the_apply_command)
        {
            apply_command = Guard.IsNotNull(the_apply_command, "the_apply_command");
        }

        private readonly IApplyShiftBreaksFromBreakTemplateForAllOccurrences apply_command;
    }
}
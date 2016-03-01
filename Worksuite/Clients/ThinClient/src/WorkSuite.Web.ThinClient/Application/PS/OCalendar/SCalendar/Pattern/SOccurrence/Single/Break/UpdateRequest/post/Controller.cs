using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Commands.Edit
{
    /// <summary>
    /// The file name for this class has been named just controller.
    /// This is because VS & TFS do not allow a file path to exceed a certain count
    /// </summary>
    public class EditShiftBreakController : Controller
    {
        public ActionResult SubmitRequest(EditShiftBreakRequest request)
        {
            var response = command.execute(request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public EditShiftBreakController(IEditShiftBreak the_command)
        {
            command = Guard.IsNotNull(the_command, "the_command");
        }

        private readonly IEditShiftBreak command;
    }
}
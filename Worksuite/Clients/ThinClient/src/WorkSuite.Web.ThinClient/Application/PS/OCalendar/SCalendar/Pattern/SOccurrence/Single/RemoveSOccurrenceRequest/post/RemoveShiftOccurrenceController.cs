using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Remove.Command.Remove
{
    public class RemoveShiftOccurrenceController : Controller
    {
        public ActionResult SubmitRequest(ShiftOccurrenceIdentity request)
        {
            var response = remove_command.execute(request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveShiftOccurrenceController(IRemoveShiftOccurrence the_remove_command)
        {
            remove_command = Guard.IsNotNull(the_remove_command, "the_remove_command");
        }

        private readonly IRemoveShiftOccurrence remove_command;

    }
}

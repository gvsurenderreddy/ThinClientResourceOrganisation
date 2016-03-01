using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.RemoveAll.Command.RemoveAll
{
    public class RemoveAllOccurrenceController : Controller
    {
        public ActionResult SubmitRequest(ShiftOccurrenceIdentity request)
        {
            var response = remove_all_shift_occurrence_command.execute(request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveAllOccurrenceController(IRemoveAllShiftOccurrences the_remove_all_shift_occurrence_command)
        {
            remove_all_shift_occurrence_command = Guard.IsNotNull(the_remove_all_shift_occurrence_command, "the_remove_all_shift_occurrence_command");
        }

        private readonly IRemoveAllShiftOccurrences remove_all_shift_occurrence_command;
    }
}
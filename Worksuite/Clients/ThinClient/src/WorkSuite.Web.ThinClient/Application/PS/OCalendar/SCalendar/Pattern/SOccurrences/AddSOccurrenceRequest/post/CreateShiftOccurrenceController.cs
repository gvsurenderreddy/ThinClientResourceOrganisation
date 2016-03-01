using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.New.Commands.New
{
    public class CreateShiftOccurrenceController : Controller
    {
        public ActionResult SubmitRequest(NewShiftOccurrenceRequest request)
        {
            var response = create_command.execute(request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateShiftOccurrenceController(INewShiftOccurrence the_create_command)
        {
            create_command = Guard.IsNotNull(the_create_command, "the_create_command");
        }
        private readonly INewShiftOccurrence create_command;
    }
}
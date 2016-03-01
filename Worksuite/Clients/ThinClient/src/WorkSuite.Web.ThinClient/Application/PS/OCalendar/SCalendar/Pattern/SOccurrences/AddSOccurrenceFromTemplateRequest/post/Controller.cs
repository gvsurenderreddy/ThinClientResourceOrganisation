using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Commands.CreateFromShiftTemplate
{
    /// <summary>
    /// The file name for this class has been named just controller.
    /// This is because VS & TFS do not allow a file path to exceed a certain count
    /// </summary>
    public class CreateShiftOccurrenceFromShiftTemplateController : Controller
    {
        public ActionResult SubmitRequest(NewShiftOccurrenceFromShiftTemplateRequest new_shift_calendar_pattern_request)
        {
            var response = create_command.execute(new_shift_calendar_pattern_request);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public CreateShiftOccurrenceFromShiftTemplateController(INewShiftOccurrenceFromShiftTemplate the_create_command)
        {
            create_command = Guard.IsNotNull(the_create_command, "the_create_command");
        }

        private readonly INewShiftOccurrenceFromShiftTemplate create_command;
    }
}
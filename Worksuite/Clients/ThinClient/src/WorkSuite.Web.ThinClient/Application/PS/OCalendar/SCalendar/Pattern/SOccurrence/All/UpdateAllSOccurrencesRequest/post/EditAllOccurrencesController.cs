using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.EditAll.Command.UpdateAll
{
    public class EditAllOccurrencesController
                    : Controller
    {
        public ActionResult SubmitRequest(EditAllShiftOccurrencesRequest the_request)
        {
            var response = edit_all_shift_occurrences
                                .execute(the_request)
                                ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public EditAllOccurrencesController(IEditAllShiftOccurrences the_edit_all_shift_occurrences)
        {
            edit_all_shift_occurrences = Guard.IsNotNull(the_edit_all_shift_occurrences,
                                                         "the_edit_all_shift_occurrences"
                                                        );
        }

        private readonly IEditAllShiftOccurrences edit_all_shift_occurrences;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Edit.Command.Update
{
    public class EditSingleShiftOccurrenceController 
                                           : Controller
    {
        public ActionResult SubmitRequest(EditSingleShiftOccurrenceRequest the_request)
        {
            var response = edit_single_shift_occurrence.execute(the_request);

            Response.StatusCode = response.has_errors ? 400 : 200;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

         public EditSingleShiftOccurrenceController(IEditSingleShiftOcuurrence the_edit_single_shift_occurrence )
         {
             edit_single_shift_occurrence = Guard.IsNotNull(the_edit_single_shift_occurrence,"the_edit_single_shift_occurrence");
         }

        private readonly IEditSingleShiftOcuurrence edit_single_shift_occurrence;
    }
}
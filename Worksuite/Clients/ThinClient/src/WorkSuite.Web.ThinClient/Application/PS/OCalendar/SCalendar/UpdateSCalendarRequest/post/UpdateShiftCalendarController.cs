using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Commands.Update
{
    public class UpdateShiftCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest(UpdateShiftCalendarRequest the_update_shift_calendar_request)
        {
            UpdateShiftCalendarResponse response = _update_shift_calendar
                                                        .execute(the_update_shift_calendar_request)
                                                        ;

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public UpdateShiftCalendarController(IUpdateShiftCalendar the_update_shift_calendar)
        {
            _update_shift_calendar = Guard.IsNotNull(the_update_shift_calendar, "the_update_shift_calendar");
        }

        private readonly IUpdateShiftCalendar _update_shift_calendar;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Commands.Remove
{
    public class RemoveShiftCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest(ShiftCalendarIdentity the_remove_shift_calendar)
        {
            var response = _remove_shift_calendar.execute(the_remove_shift_calendar);

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public RemoveShiftCalendarController(IRemoveShiftCalendar the_remove_shift_calendar)
        {
            _remove_shift_calendar = Guard.IsNotNull(the_remove_shift_calendar, "the_remove_shift_calendar");
        }

        private readonly IRemoveShiftCalendar _remove_shift_calendar;
    }
}
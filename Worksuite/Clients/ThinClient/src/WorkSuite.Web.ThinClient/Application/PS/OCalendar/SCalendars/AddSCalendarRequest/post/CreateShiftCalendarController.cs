using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Commands.New.Create
{
    public class CreateShiftCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest(NewShiftCalendarRequest the_new_shift_calendar_request)
        {
            NewShiftCalendarResponse new_shift_calendar_response = _new_shift_calendar.execute(the_new_shift_calendar_request);

            Response.StatusCode = new_shift_calendar_response.has_errors ? 400 : 200;

            return Json(new_shift_calendar_response, JsonRequestBehavior.AllowGet);
        }

        public CreateShiftCalendarController(INewShiftCalendar the_new_shift_calendar)
        {
            _new_shift_calendar = Guard.IsNotNull(the_new_shift_calendar, "the_new_shift_calendar");
        }

        private readonly INewShiftCalendar _new_shift_calendar;
    }
}
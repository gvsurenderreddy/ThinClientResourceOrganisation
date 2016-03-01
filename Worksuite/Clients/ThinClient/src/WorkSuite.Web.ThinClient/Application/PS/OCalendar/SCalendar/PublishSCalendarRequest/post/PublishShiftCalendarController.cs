using System.Web.Mvc;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Commands.Publish
{
    public class PublishShiftCalendarController
                              : Controller
    {
        public ActionResult SubmitRequest(PublishShiftCalendarRequest publish_shift_calendar_request)
        {
            PublishShiftCalendarResponse new_shift_calendar_response = publish_shift_calendar.execute(publish_shift_calendar_request);

            Response.StatusCode = new_shift_calendar_response.has_errors ? 400 : 200;

            return Json(new_shift_calendar_response, JsonRequestBehavior.AllowGet);
        }

        public PublishShiftCalendarController(IPublishShiftCalendar the_publish_shift_calendar)
        {
            publish_shift_calendar = the_publish_shift_calendar;
        }

        private readonly IPublishShiftCalendar publish_shift_calendar;
    }
}
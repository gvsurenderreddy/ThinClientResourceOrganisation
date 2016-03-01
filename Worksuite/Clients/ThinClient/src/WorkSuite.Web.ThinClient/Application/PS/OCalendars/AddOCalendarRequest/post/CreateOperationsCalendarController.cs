using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.New.Commands.Create
{
    public class CreateOperationsCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest( NewOperationsCalendarRequest the_new_operations_calendar_request )
        {
            NewOperationsCalendarResponse new_operations_calendar_response = _new_operations_calendar.execute( the_new_operations_calendar_request );

            Response.StatusCode = new_operations_calendar_response.has_errors ? 400 : 200;

            return Json( new_operations_calendar_response, JsonRequestBehavior.AllowGet );
        }

        public CreateOperationsCalendarController( INewOperationsCalendar the_new_operations_calendar )
        {
            _new_operations_calendar = Guard.IsNotNull( the_new_operations_calendar, "the_new_operations_calendar" );
        }

        private readonly INewOperationsCalendar _new_operations_calendar;
    }
}
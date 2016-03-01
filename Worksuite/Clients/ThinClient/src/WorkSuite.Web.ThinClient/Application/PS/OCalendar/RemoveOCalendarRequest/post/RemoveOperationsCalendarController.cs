using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Remove.Commands.Remove
{
    public class RemoveOperationsCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest( OperationsCalendarIdentity the_remove_operations_calender )
        {
            var response = _remove_operations_calendar.execute( the_remove_operations_calender );

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public RemoveOperationsCalendarController( IRemoveOperationsCalendar the_remove_operations_calendar )
        {
            _remove_operations_calendar = Guard.IsNotNull(  the_remove_operations_calendar,
                                                            "the_remove_operations_calendar"
                                                         );
        }

        private readonly IRemoveOperationsCalendar _remove_operations_calendar;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Edit.Commands.Update
{
    public class UpdateOperationsCalendarController
                        : Controller
    {
        public ActionResult SubmitRequest( UpdateOperationsCalendarRequest the_update_operations_calendar_request )
        {
            UpdateOperationsCalendarResponse response   = _updateOperationsCalendar
                                                                    .execute( the_update_operations_calendar_request );

            Response.StatusCode = response.has_errors ? 400 : 200;

            return Json( response, JsonRequestBehavior.AllowGet );
        }

        public UpdateOperationsCalendarController( IUpdateOperationsCalendar the_update_operations_calendar )
        {
            _updateOperationsCalendar = Guard.IsNotNull(    the_update_operations_calendar,
                                                            "the_update_operations_calendar"
                                                       );
        }

        private readonly IUpdateOperationsCalendar _updateOperationsCalendar;
    }
}
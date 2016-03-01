using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Commands.Update
{
    public class UpdateNoteController : Controller
    {
          public ActionResult SubmitRequest
            ( UpdateRequest update_request ) {

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

          public UpdateNoteController
            ( IUpdate update_command ) {

            Guard.IsNotNull( update_command, "update_command" );

            update = update_command;
        }

        private readonly IUpdate update;
    }
}
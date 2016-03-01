using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Update
{
    public class UpdateTitleController : Controller
    {
         public ActionResult SubmitRequest
            ( UpdateTitleRequest update_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

         public UpdateTitleController
            ( IUpdateTitle update_command ) {

            Guard.IsNotNull( update_command, "update_command" );

            update = update_command;
        }

        private readonly IUpdateTitle update;
    }
}
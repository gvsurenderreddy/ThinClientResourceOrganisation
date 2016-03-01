using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Commands.Create
{
    public class CreateNoteController : Controller
    {
        public ActionResult SubmitRequest
            ( NewNoteRequest create_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = create.execute( create_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

        public CreateNoteController
            ( INewNote create_command ) {

            Guard.IsNotNull( create_command, "create_command" );

            create = create_command;
        }

        private readonly INewNote create;
    }
}

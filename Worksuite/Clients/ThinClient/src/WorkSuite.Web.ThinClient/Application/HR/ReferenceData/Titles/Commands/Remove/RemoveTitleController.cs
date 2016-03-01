using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Remove {
    public class RemoveTitleController : Controller {

        private readonly IRemoveTitle remove;

        public ActionResult SubmitRequest ( RemoveTitleRequest remove_request ) {
            // to do: validate the update_request that was built from the request.

            var remove_response = remove.execute( remove_request );

            Response.StatusCode = remove_response.has_errors ? 400 : 200;

            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }

        public RemoveTitleController ( IRemoveTitle remove_command ) {
            remove = Guard.IsNotNull( remove_command, "remove_command" );
        }

    }
}
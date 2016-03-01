using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Commands.Remove {

    public class RemoveGenderController
                    : Controller {

        public ActionResult SubmitRequest 
                                ( RemoveGenderRequest remove_request ) {
            // to do: validate the update_request that was built from the request.

            var remove_response = remove.execute( remove_request );

            Response.StatusCode = remove_response.has_errors ? 400 : 200;

            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public RemoveGenderController 
                    ( IRemoveGender remove_command ) {

            remove = Guard.IsNotNull( remove_command, "remove_command" );
        }

        private readonly IRemoveGender remove;
    }
}
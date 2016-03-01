using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Commands.Update {

    public class UpdateGenderController
                    : Controller {

         public ActionResult SubmitRequest
                                ( UpdateGenderRequest update_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

         public UpdateGenderController
                    ( IUpdateGender update_command ) {

            update = Guard.IsNotNull( update_command, "update_command" );

        }

        private readonly IUpdateGender update;
    }
}
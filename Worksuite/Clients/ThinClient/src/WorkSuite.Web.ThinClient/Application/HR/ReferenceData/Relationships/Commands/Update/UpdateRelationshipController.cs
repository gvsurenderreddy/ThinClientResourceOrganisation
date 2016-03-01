using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Commands.Update {

    public class UpdateRelationshipController
                    : Controller {

         public ActionResult SubmitRequest
                                ( UpdateRelationshipRequest update_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

         public UpdateRelationshipController
                    ( IUpdateRelationship update_command ) {

            update = Guard.IsNotNull( update_command, "update_command" );

        }

        private readonly IUpdateRelationship update;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Commands.Create
{
    public class CreateRelationshipController
                    : Controller
    {

        public ActionResult SubmitRequest
                                (CreateRelationshipRequest create_request)
        {

            // to do: validate the update_request that was built from the request.

            var update_response = create.execute(create_request);

            Response.StatusCode = update_response.has_errors ? 400 : 200;

            return Json(update_response, JsonRequestBehavior.AllowGet);

        }

        public CreateRelationshipController
                    (ICreateRelationship create_command)
        {

            create = Guard.IsNotNull(create_command, "create_command");
        }

        private readonly ICreateRelationship create;
    }
}
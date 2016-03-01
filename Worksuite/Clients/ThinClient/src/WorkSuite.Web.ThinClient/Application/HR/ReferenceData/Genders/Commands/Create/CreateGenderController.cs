using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Commands.Create {


    public class CreateGenderController
                    : Controller {

        public ActionResult SubmitRequest
                                ( CreateGenderRequest create_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = create.execute( create_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

        public CreateGenderController
                    ( ICreateGender create_command ) {

            create = Guard.IsNotNull( create_command, "create_command" );
        }

        private readonly ICreateGender create;
    }
}

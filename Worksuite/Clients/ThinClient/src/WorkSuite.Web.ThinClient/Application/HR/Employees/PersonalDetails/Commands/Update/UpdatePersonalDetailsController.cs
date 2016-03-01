using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Commands.Update
{

    public class UpdatePersonalDetailsController : Controller {

        public ActionResult SubmitRequest
            ( UpdateEmployeePersonalDetailsRequest update_request ) {

            // to do: validate the update_request that was built from the request.

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

        public UpdatePersonalDetailsController
            ( IUpdateEmployeePersonalDetails update_command ) {

            Guard.IsNotNull( update_command, "update_command" );

            update = update_command;
        }

        private readonly IUpdateEmployeePersonalDetails update;

    }

}
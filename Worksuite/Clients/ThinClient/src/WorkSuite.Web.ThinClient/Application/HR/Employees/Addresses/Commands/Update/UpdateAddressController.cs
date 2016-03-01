using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Update
{
    public class UpdateAddressController : Controller
    {
        
        public ActionResult SubmitRequest
            ( UpdateAddressRequest update_request ) {

            var update_response = update.execute( update_request );

            Response.StatusCode = update_response.has_errors ? 400 : 200;
            
            return Json( update_response, JsonRequestBehavior.AllowGet );

        }

        public UpdateAddressController
            ( IUpdateAddress update_command ) {

            Guard.IsNotNull( update_command, "update_command" );

            update = update_command;
        }

        private readonly IUpdateAddress update;
         
    }
}
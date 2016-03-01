using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Remove
{
    public class RemoveAddressController : Controller
    {
        public ActionResult SubmitRequest ( AddressIdentity remove_request ) {
            // to do: validate the update_request that was built from the request.

            var remove_response = remove.execute( remove_request );

            Response.StatusCode = remove_response.has_errors ? 400 : 200;

            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public RemoveAddressController(IRemoveAddress remove_command)
        {

            remove = Guard.IsNotNull( remove_command, "remove_command" );

        }

        private readonly IRemoveAddress remove;
    }
}
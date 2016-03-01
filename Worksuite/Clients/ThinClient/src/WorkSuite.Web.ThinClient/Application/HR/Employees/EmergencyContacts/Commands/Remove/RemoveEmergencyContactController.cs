using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Remove
{
    public class RemoveEmergencyContactController : Controller
    {
        public ActionResult SubmitRequest ( EmergencyContactIdentity remove_request ) {

            var remove_response = remove.execute( remove_request );

            Response.StatusCode = remove_response.has_errors ? 400 : 200;

            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public RemoveEmergencyContactController(IRemoveEmergencyContact remove_command)
        {

            remove = Guard.IsNotNull( remove_command, "remove_command" );

        }

        private readonly IRemoveEmergencyContact remove;
    }
}
using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Reorder
{
    public class ReorderEmergencyContactController
                            : Controller
    {
        public ReorderEmergencyContactController( IReorderEmergencyContact the_reorder_emergency_contact_command )
        {
            _reorder_command = Guard.IsNotNull( the_reorder_emergency_contact_command,
                "the_reorder_emergency_contact_command" );
        }

        public ActionResult SubmitRequest( ReorderEmergencyContactRequest the_reorder_emeregency_contact_request )
        {
            var reorder_respone = _reorder_command.execute( the_reorder_emeregency_contact_request );

            Response.StatusCode = reorder_respone.has_errors ? 400 : 200;

            return Json( reorder_respone, JsonRequestBehavior.AllowGet );
        }

        private readonly IReorderEmergencyContact _reorder_command;
    }
}
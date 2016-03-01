using System.Web.Mvc;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Command;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Controller {

    public class EndMaintenanceSessionController
                    : System.Web.Mvc.Controller {


        public ActionResult SubmitRequest() {

            var end_maintenance_session_response = end_maintenance_session.execute();

            Response.StatusCode = end_maintenance_session_response.has_errors ? 400 : 200;

            return Json( end_maintenance_session_response, JsonRequestBehavior.AllowGet );
        }

        public EndMaintenanceSessionController 
                ( EndMaintenanceSession end_maintenance_session_command ) {

            end_maintenance_session = Guard.IsNotNull( end_maintenance_session_command, "end_maintenance_session_command" );
        }


        // client layer command used to end a maintenance session
        private readonly EndMaintenanceSession end_maintenance_session;
    }
}
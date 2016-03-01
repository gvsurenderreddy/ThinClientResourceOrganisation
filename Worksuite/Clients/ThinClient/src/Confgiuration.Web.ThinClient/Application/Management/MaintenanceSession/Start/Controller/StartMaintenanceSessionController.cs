using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Controller {

    // Improve: We are going to get very bored of typing this, it should be made generic
    public class StartMaintenanceSessionController 
                    : System.Web.Mvc.Controller {

        public ActionResult SubmitRequest(  ) {

            var start_maintenance_session_response = start_maintenance_session.execute( );

            Response.StatusCode = start_maintenance_session_response.has_errors ? 400 : 200;
            return Json( start_maintenance_session_response, JsonRequestBehavior.AllowGet );
        }

        public StartMaintenanceSessionController
                ( StartMaintenanceSession start_maintenance_session_command ) {

            start_maintenance_session = Guard.IsNotNull( start_maintenance_session_command , "start_maintenance_session_command " );
        }

        private readonly StartMaintenanceSession start_maintenance_session;
    }
}
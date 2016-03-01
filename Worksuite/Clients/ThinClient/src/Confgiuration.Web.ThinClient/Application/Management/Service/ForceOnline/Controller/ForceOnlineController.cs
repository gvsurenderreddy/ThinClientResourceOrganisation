using System.Web.Mvc;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Controller {

    public class ForceOnlineController 
                    : System.Web.Mvc.Controller {


        public ActionResult SubmitRequest 
                                ( EndAllMaintenanceSessionsRequest request ) {

            var end_all_maintenace_session_response = end_all_maintenance_sessions.execute( request );

            Response.StatusCode = end_all_maintenace_session_response.has_errors ? 400 : 200;

            return Json( end_all_maintenace_session_response, JsonRequestBehavior.AllowGet );
        }

        public ForceOnlineController 
                ( IEndAllMaintenanceSessions end_all_maintenance_sessions_command ) {

            end_all_maintenance_sessions = Guard.IsNotNull( end_all_maintenance_sessions_command, "end_all_maintenance_sessions_command" );
        }

        private readonly IEndAllMaintenanceSessions end_all_maintenance_sessions;
    }
}
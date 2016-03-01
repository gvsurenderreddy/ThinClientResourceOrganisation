using System.Web;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command {

    public class StartMaintenanceSession {

        public StartMaintenanceSessionResponse execute() {
            // Improve: once internal error handling has been defined deal with error writing to cookies appropriately
            var response = start_session.execute();

            if ( !response.has_errors ) {
                add_session_cookie( response.result );
            }
            return response;
        }

        public StartMaintenanceSession 
                ( IStartMaintenanceSession start_session_command
                , IResponseCookies the_repsonse_cookies) {

            start_session = Guard.IsNotNull( start_session_command ,"start_session_command" );
            repsonse_cookies = Guard.IsNotNull( the_repsonse_cookies, "the_repsonse_cookies" );
        }

        // add the maintenance session cookie to the response, overwrites any existing maintenance session cookie 
        private void add_session_cookie
                        ( MaintenanceSessionIdentity session_id ) {

            var maintenance_session_cookie = new HttpCookie( StartMaintenanceSessionConstants.maintenance_session_cookie_name );
                maintenance_session_cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ] = session_id.maintenance_session_id.ToString();

            repsonse_cookies.add( maintenance_session_cookie );
        }

        private readonly IStartMaintenanceSession start_session;
        private readonly IResponseCookies repsonse_cookies;
    }
}
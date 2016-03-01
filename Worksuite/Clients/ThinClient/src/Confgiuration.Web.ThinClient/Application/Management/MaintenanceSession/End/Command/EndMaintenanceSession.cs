using System;
using System.Web;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.RequestCookies;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.ResponseCookies;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Command {

    /// <summary>
    ///     Ends a maintenance session 
    /// </summary>
    public class EndMaintenanceSession {


        public EndMaintenanceSessionResponse execute () {

            return this
                    .get_current_maitenance_session ()
                    .end_maintenace_session_on_service_layer ()
                    .clear_current_maintenance_session ()
                    .build_response()
                    ;
        }

        public EndMaintenanceSession 
                    ( IRequestCookies the_request_cookies
                    , IEndMaintenanceSession end_session_command
                    , IResponseCookies the_response_cookies ) {

            request_cookies = Guard.IsNotNull( the_request_cookies, "the_request_cookies" );
            end_session = Guard.IsNotNull( end_session_command, "end_session_command" );
            response_cookies = Guard.IsNotNull( the_response_cookies, "the_response_cookies" );
        }


        private EndMaintenanceSession get_current_maitenance_session () {

            current_maintenance_session =  request_cookies.get( StartMaintenanceSessionConstants.maintenance_session_cookie_name ) 
                                        ?? new HttpCookie( StartMaintenanceSessionConstants.maintenance_session_cookie_name )
                                        ;

            return this;
        }

        private EndMaintenanceSession end_maintenace_session_on_service_layer () {
            
            Guard.IsNotNull( current_maintenance_session, "current_maintenance_session" );

            end_maintenance_session_response = end_session.execute( new MaintenanceSessionIdentity {
                maintenance_session_id = get_session_id( current_maintenance_session )
            });
            return this;
        }

        private EndMaintenanceSession clear_current_maintenance_session () {
            
            var reponse_cookie = new HttpCookie( StartMaintenanceSessionConstants.maintenance_session_cookie_name );
                reponse_cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ] = (-1).ToString();
                response_cookies.add( reponse_cookie );
            
            return this;
        }

        private EndMaintenanceSessionResponse build_response () {
            
            Guard.IsNotNull( end_maintenance_session_response, "end_maintenance_session_response" );

            return end_maintenance_session_response;
        }

        private int get_session_id
                        ( HttpCookie cookie ) {

            Guard.IsNotNull(cookie, "cookie");

            // todo: I have the litteral -1 scattered all over the place I should consolidate into a constant

            try {

                return Convert.ToInt32( cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ]);

            } catch {

                return -1;
            }
        }

        private readonly IRequestCookies request_cookies;
        private readonly IResponseCookies response_cookies;
        private readonly IEndMaintenanceSession end_session;

        private HttpCookie current_maintenance_session;
        private EndMaintenanceSessionResponse end_maintenance_session_response;
    }
}
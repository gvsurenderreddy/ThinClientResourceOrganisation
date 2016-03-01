using System;
using System.Web;
using System.Web.Mvc;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.Cookies.RequestCookies;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query {

    public class GetMaintenanceSessionStatus {

        public static bool is_in_session()
        {
            var verfiier = DependencyResolver.Current.GetService<GetMaintenanceSessionStatus>();
            var session_status =  verfiier.execute().result;
            return session_status.state.ToString() == "active" ;
        }
        
        public GetMaintenanceSessionStatusResponse execute () {

            return this
                    .get_cookie()
                    .get_maintenance_session_status()
                    .build_result()
                    ;
        }

        public GetMaintenanceSessionStatus 
                ( IRequestCookies the_cookies
                , IGetMaintenanceSessionById get_maintenance_session_query ) {

            cookies = Guard.IsNotNull( the_cookies, "the_cookies" );
            get_maintenance_session = Guard.IsNotNull( get_maintenance_session_query, "get_maintenance_session_query");
        }

        private GetMaintenanceSessionStatus get_cookie () {

            maintenace_session_cookie = cookies.get( StartMaintenanceSessionConstants.maintenance_session_cookie_name ) ?? new HttpCookie( StartMaintenanceSessionConstants.maintenance_session_cookie_name );
            return this;
        }

        private GetMaintenanceSessionStatus get_maintenance_session_status () {

            Guard.IsNotNull( maintenace_session_cookie, "maintenace_session_cookie" );

            // the cookie must have a session and that session must exist in the service layer
            maintenace_session_status = is_in_session( maintenace_session_cookie ) && session_exist( maintenace_session_cookie )
                                            ? new InMaintenanceSession() as AMaintenanceSesssionStatus 
                                            : new NotInMaintenanceSession() as AMaintenanceSesssionStatus
                                            ;
            return this;
        }


        private bool is_in_session
                        ( HttpCookie cookie ) {

            Guard.IsNotNull( cookie, "cookie" );

            return !String.IsNullOrWhiteSpace( cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ] );
        }

        private bool session_exist
                        ( HttpCookie cookie ) {
            
            Guard.IsNotNull( cookie, "cookie" );

            var session_id = new MaintenanceSessionIdentity {
                maintenance_session_id = get_session_id( cookie ),
            };

            return !get_maintenance_session.execute( session_id ).has_errors;
        }

        private int get_session_id
                        ( HttpCookie cookie ) {
            
            Guard.IsNotNull( cookie, "cookie" );

            // todo: I have the litteral -1 scattered all over the place I should consolidate into a constant

            try {
                return Convert.ToInt32( cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ] );

            } catch {
                return -1;
            }
        }

        private GetMaintenanceSessionStatusResponse build_result () {

            Guard.IsNotNull( maintenace_session_status, "maintenace_session_status" );


            var response_builder = new ResponseBuilder<AMaintenanceSesssionStatus, GetMaintenanceSessionStatusResponse>();
                response_builder.set_response( maintenace_session_status );

            return response_builder.build();
        }


        // collection where the maintenance session cookie should live if there is one.
        private readonly IRequestCookies cookies;
        private readonly IGetMaintenanceSessionById get_maintenance_session;

        private HttpCookie maintenace_session_cookie;
        private AMaintenanceSesssionStatus maintenace_session_status;        
    }
}
using System.Web;
using Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Status.Query {

    [TestClass]
    public class The_maintenance_session_status_is {
        
        // done: active if this session has a an active maintenance session 
        // done: not active if the session does exist in the service layer
        // done: not active if this session has a an active maintenance session 

        [TestMethod]
        public void active_if_this_session_has_a_an_active_maintenance_session ( ) {

            var cookie = new HttpCookie( StartMaintenanceSessionConstants.maintenance_session_cookie_name );
                cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ] = "10";

            request_cookies.cookies.Add( cookie );
            service_layer.maintenance_session_id = 10;

            then_maintenance_status_is_active( query.execute() );
        }

        [TestMethod]
        public void not_active_if_the_session_does_exist_in_the_service_layer () {

            var cookie = new HttpCookie(StartMaintenanceSessionConstants.maintenance_session_cookie_name);
                cookie[StartMaintenanceSessionConstants.cookie_session_id_name] = "10";

            request_cookies.cookies.Add( cookie );

            then_maintenance_status_is_not_active( query.execute() );
        }

        [TestMethod]
        public void not_active_if_this_session_does_not_bane_an_active_maintenance_session () {

            then_maintenance_status_is_not_active( query.execute() );
        }


        [TestInitialize]
        public void before_each_test () {
            request_cookies = new FakeRequestCookies();
            service_layer = new FakeServiceLayerQuery();
            query = new GetMaintenanceSessionStatus( request_cookies, service_layer );
        }

        private void then_maintenance_status_is_not_active
                        ( GetMaintenanceSessionStatusResponse response ) {
            
            response.result.Should().BeOfType<NotInMaintenanceSession>();
            response.result.state.Should().Be(MaintenanceSessionState.not_active);                
        }

        private void then_maintenance_status_is_active
                        ( GetMaintenanceSessionStatusResponse response ) {

            response.result.Should().BeOfType<InMaintenanceSession>();
            response.result.state.Should().Be(MaintenanceSessionState.active);
        }
        

        private FakeRequestCookies request_cookies;
        private GetMaintenanceSessionStatus query;
        private FakeServiceLayerQuery service_layer;
    }

}
using Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Start.Command {

    [TestClass]
    public class Start_will {

        // done: write the session id to the maintenance session cookie
        // done: not create the maintenance session cookie if there was an error creating the response
        // done: retrun the response from the service layer command.

        [TestMethod]
        public void write_the_session_id_to_the_maintenance_session_cookie () {
            service_layer_command.maintenance_session_id = 10;

            command.execute();

            response_cookies.cookies[ StartMaintenanceSessionConstants.maintenance_session_cookie_name ].Should().NotBeNull();
            response_cookies.cookies[ StartMaintenanceSessionConstants.maintenance_session_cookie_name ][ StartMaintenanceSessionConstants.cookie_session_id_name ].Should().Be(service_layer_command.maintenance_session_id.ToString());
        }

        [TestMethod]
        public void not_create_the_maintenance_session_cookie_if_there_was_an_error_creating_the_response () {
            service_layer_command.has_errors = true;

            command.execute();

            response_cookies.cookies[StartMaintenanceSessionConstants.maintenance_session_cookie_name].Should().BeNull();            
        }

        [TestMethod]
        public void retrun_the_response_from_the_service_layer_command () {
            service_layer_command.maintenance_session_id = 10;

            command.execute().Should().Be( service_layer_command.response );
        }

        [TestInitialize]
        public void berfore_each_test () {
            service_layer_command = new FakeServiceLayerStartMaintenanceSession();
            response_cookies = new FakeResponseCookies();
            command = new StartMaintenanceSession(service_layer_command, response_cookies);           
        }

        private FakeServiceLayerStartMaintenanceSession service_layer_command;
        private FakeResponseCookies response_cookies;
        private StartMaintenanceSession command;
    }
}
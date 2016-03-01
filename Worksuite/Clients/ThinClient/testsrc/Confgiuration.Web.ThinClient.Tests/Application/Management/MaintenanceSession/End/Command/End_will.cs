using System;
using Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Command;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Command;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.End.Command {

    [TestClass]
    public class End_will {

        // done: clear the maintenance session id in the session cookie
        // done: return the response from the service layer
       

        [TestMethod]
        public void clear_the_maintenance_session_id_in_the_session_cookie () {
            
            command.execute();

            var maintenance_session_cookie = response_cookies.cookies[ StartMaintenanceSessionConstants.maintenance_session_cookie_name ];

            maintenance_session_cookie[ StartMaintenanceSessionConstants.cookie_session_id_name ].Should().Be( "-1");
        }

        [TestMethod]
        public void return_the_response_from_the_service_layer() {

            command.execute().Should().Be(service_layer.response);

        }

        [TestInitialize]
        public void berfore_each_test() {
            request_cookies = new FakeRequestCookies();
            service_layer = new FakeServiceLayerEndMaintenanceSession();
            response_cookies = new FakeResponseCookies();
            command = new EndMaintenanceSession(request_cookies, service_layer, response_cookies);
        }


        private FakeRequestCookies request_cookies;
        private FakeResponseCookies response_cookies;
        private FakeServiceLayerEndMaintenanceSession service_layer;
        private EndMaintenanceSession command;
    }
}
using System.Web;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.GetMaintenanceSessionStatusQuery;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.GetMaintenanceSessionStatusQuery {

    [TestClass]
    public class The_maintenance_session_status_will {

        // done: be not in maintenance session if current session is not in a maintenance session
        // done: be in a maintenance session if current session has started but not stopped a maintenance sesssion 

        [TestMethod]
        public void be_not_in_maintenance_session_if_current_session_is_not_in_a_maintenance_session () {

            query.execute().result.Should().BeOfType<NotInMaintenanceSession>();
        }


        [TestMethod]
        public void be_in_a_maintenance_session_if_current_session_has_started_but_not_stopped_a_maintenance_sesssion () {

            given_that_a_maintenace_session_has_been_started();
            query.execute().result.Should().BeOfType<InMaintenanceSession>();
        }

        [TestInitialize]
        public void before_each_test () {
            cookies = new HttpCookieCollection();
            query = new GetMaintenanceSessionStatus( cookies );
        }


        private void given_that_a_maintenace_session_has_been_started () {

            cookies.Add( create_maintenance_session_cooky( 1 ));
        }

        private HttpCookie create_maintenance_session_cooky
                            ( int? session_id = null ) {

            var result = new HttpCookie("maintenance_session");

            if (session_id.HasValue) {
                result.Values[ "session_id" ] = session_id.Value.ToString();
            }
            return result;
        }

        private GetMaintenanceSessionStatus query;
        private HttpCookieCollection cookies;
    }
}
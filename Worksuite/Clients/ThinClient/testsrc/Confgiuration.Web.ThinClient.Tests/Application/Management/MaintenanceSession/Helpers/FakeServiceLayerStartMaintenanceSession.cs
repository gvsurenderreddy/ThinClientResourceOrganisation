using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.Start;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers {
    internal class FakeServiceLayerStartMaintenanceSession : IStartMaintenanceSession {

        public StartMaintenanceSessionResponse execute () {

            response = new StartMaintenanceSessionResponse {
                has_errors = has_errors,
                messages = new ResponseMessage[] {},
                result = new MaintenanceSessionIdentity {
                    maintenance_session_id = 10,
                }
            };
            return response;
        }

        public int maintenance_session_id { get; set; }
        public bool has_errors { get; set; }
        public StartMaintenanceSessionResponse response { get; private set; }
    }
}
using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers {

    public class FakeServiceLayerEndMaintenanceSession
                    : IEndMaintenanceSession {

        public EndMaintenanceSessionResponse execute 
                                                ( MaintenanceSessionIdentity request ) {
            
            return response;            
        }

        public EndMaintenanceSessionResponse response = new EndMaintenanceSessionResponse {
                has_errors = false,
                messages = new ResponseMessage[] { },
        };            
    }
}
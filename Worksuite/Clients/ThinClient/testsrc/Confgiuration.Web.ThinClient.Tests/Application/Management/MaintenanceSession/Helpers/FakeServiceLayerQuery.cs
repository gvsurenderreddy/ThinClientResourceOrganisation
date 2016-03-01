using WorkSuite.Configuration.Service.Management.MaintenanceSessions;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.MaintenanceSession.Helpers {
    internal class FakeServiceLayerQuery
        : IGetMaintenanceSessionById {

        public GetMaintenanceSessionByIdResponse execute ( MaintenanceSessionIdentity request ) {

            var response_builder = new ResponseBuilder<MaintenanceSessionDetails, GetMaintenanceSessionByIdResponse>();

            response_builder.set_response( maintenace_session );

            if ( maintenace_session.maintenance_session_id == -1 ) {
                response_builder.add_error( "An error" );
            } 
            return response_builder.build();
        }

        public int maintenance_session_id {
            get { return maintenace_session.maintenance_session_id; }
            set { maintenace_session.maintenance_session_id = value;  }
        }


        private readonly MaintenanceSessionDetails maintenace_session = new MaintenanceSessionDetails {
            maintenance_session_id = -1,
        };
    }
}
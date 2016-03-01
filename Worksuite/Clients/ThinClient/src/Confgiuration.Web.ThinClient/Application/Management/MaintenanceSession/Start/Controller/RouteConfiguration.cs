using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Controller {

    public class RouteConfiguration : ARouteConfiguration<StartMaintenanceSessionController> {
        public override string id {
            get { return Resources.command_id; }
        }

        public override string url {
            get { return "maintenance/start-maintenance-session"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }
    }
}
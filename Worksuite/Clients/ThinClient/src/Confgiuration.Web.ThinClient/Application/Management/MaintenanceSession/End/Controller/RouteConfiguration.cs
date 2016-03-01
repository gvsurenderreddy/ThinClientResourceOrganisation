using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Controller {

    public class RouteConfiguration 
                    : ARouteConfiguration<EndMaintenanceSessionController> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "maintenance/end-maintenance-session";  }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }
    }
}
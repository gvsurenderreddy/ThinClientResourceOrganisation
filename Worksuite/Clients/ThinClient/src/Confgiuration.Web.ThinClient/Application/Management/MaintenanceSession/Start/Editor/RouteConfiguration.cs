using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start {

    public class RouteConfiguration 
                    : ARouteConfiguration<StartMaintenanceSessionPresenter> {

        protected override string id {

            get { return Resources.page_id; }
        }

        public override string url {

            get { return "maintenance/start-maintenance-session-editor"; }
        }

        protected override string action {
            get { return "Editor"; }
        }
    }
}
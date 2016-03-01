using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Editor {

    public class RouteConfiguration
                    : ARouteConfiguration<EditMaintenanceSessionPresenter> {
        public override string id {

            get { return Resources.editor_id; }
        }

        public override string url {

            get { return "maintenance/maintenance-session/edit"; }
        }

        public override string action {
            get { return "Editor"; }
        }
    }
}
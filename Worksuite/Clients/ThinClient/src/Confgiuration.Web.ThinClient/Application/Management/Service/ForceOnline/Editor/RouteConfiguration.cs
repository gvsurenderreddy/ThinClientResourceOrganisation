using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Editor {

    public class RouteConfiguration
                    : ARouteConfiguration<EditForceOnlinePresenter> {
        public override string id {
            get { return Resources.editor_id; }
        }

        public override string url {
            get { return "service/force-online/editor"; }
        }

        public override string action {
            get { return "Editor"; }
        }
    }
}
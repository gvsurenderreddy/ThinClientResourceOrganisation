using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Controller {

    public class RouteConfiguration
                    : ARouteConfiguration<ForceOnlineController> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "service/force-online"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }
    }
}
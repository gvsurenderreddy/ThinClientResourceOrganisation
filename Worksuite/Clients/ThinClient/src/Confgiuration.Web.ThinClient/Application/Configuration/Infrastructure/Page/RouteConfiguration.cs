using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Infrastructure.Page {

    public class RouteConfiguration 
                    : APageRouteConfiguration<InfrastructurePresenter> {
        public override string id {
            get { return Resources.page_id; }
        }

        public override string url {
            get { return "configuration/infrastructure"; }
        }
    }

}
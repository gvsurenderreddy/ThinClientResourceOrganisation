using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Home.Get {

    public class RouteConfiguration
                    : APageRouteConfiguration<HomePagePresenter> {

        public override string id {
            get { return Resources.page_id ; }
        }

        public override string url {
            get { return ""; }
        }

    }
}
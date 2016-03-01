namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Security.Users.Home {

    public class DefaultRouteConfiguration
                    : Configuration.Infrastructure.Page.RouteConfiguration {
        public override string id {

            get { return Resources.page_id; }
        }


        public override string url {
            get { return ""; }
        }
    }
}
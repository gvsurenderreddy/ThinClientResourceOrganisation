using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.JavascriptBootstrapper
{
    public class RouteConfiguration : ARouteConfiguration<ApplicationBootModuleDefintionPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "application-boot-module-definition"; }
        }

        public override string action
        {
            get { return "Index"; }
        }
    }
}
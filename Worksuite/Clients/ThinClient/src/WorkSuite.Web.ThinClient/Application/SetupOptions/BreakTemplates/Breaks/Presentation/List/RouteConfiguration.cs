using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.List
{
    public class RouteConfiguration
                    : ARouteConfiguration<BreakListPresenter>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/breaks/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
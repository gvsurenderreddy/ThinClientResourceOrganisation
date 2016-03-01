using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.New
{
    public class RouteConfiguration
                    : ARouteConfiguration<NewBreakPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/breaks/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
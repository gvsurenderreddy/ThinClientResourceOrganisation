using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Editor
{
    public class RouteConfiguration
                  : ARouteConfiguration<HelpEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "help/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
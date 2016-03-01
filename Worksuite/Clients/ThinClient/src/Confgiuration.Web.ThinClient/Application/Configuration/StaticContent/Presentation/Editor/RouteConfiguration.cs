using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Presentation.Editor
{
    public class RouteConfiguration
                :ARouteConfiguration<StaticContentEditorPresenter>
    {
        public override string id
        {
            get { return Resourcse.id; }
        }

        public override string url
        {
            get { return "static-content/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Commands.Update
{
    public class RouteConfiguration
        :ARouteConfiguration<UpdateStaticContentController>
    {
        public override string id
        {
            get { return Resources.editor_id; }
        }

        public override string url
        {
            get { return "static-content/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
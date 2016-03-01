using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.NamedRouteMetadata.Presentation
{
    public class RouteConfiguration : ARouteConfiguration<NamedRouteMetadataPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "named-routes"; }
        }

        public override string action
        {
            get { return "Data"; }
        }
    }
}
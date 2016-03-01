using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Presentation.List
{
    public class RouteConfiguration
                    : ARouteConfiguration<LocationListPresenter>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "locations/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
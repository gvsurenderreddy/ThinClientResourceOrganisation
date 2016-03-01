using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Remove
{
    public class RouteConfiguration
                    : ARouteConfiguration<RemoveLocationController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "locations/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
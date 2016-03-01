using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Update
{
    public class RouteConfiguration
                    : ARouteConfiguration<UpdateLocationController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "locations/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
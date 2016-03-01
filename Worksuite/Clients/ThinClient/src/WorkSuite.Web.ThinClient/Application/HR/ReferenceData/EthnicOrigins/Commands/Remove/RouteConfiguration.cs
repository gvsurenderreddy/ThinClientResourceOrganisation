using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveEthnicOriginController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "ethnic-origins/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
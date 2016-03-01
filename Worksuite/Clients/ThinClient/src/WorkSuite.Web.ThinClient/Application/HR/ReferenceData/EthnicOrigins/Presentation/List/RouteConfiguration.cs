using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.List
{
    public class RouteConfiguration
                    : ARouteConfiguration< EthnicOriginListPresenter >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "ethnic-origins/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.List
{
    public class RouteConfiguration
                        : ARouteConfiguration<MaritalStatusListPresenter>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "marital-statuses/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
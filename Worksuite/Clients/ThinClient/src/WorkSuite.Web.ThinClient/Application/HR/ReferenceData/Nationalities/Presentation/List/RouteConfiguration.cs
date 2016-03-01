using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.List
{
    public class RouteConfiguration
                        : ARouteConfiguration< NationalityListPresenter >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "nationalities/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
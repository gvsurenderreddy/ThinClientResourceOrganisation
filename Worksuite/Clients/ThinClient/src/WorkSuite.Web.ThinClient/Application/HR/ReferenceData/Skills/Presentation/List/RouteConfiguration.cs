using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.List
{
    public class RouteConfiguration
                        :   ARouteConfiguration< SkillListPresenter >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "skills/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}
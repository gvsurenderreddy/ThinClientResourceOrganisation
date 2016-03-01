using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.New
{
    public class RouteConfiguration
                        :   ARouteConfiguration<NewSkillPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "skills/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Skills.Presentation.Editor
{
    public class RouteConfiguration
                        :   ARouteConfiguration< SkillEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "skills/{id}/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
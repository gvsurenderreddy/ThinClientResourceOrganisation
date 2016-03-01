using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration< QualificationEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "qualifications/{id}/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
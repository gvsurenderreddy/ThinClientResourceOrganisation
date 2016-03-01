using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration< NationalityEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "nationalities/{id}/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
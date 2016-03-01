using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration< EthnicOriginEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "ethnic-origins/{id}/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
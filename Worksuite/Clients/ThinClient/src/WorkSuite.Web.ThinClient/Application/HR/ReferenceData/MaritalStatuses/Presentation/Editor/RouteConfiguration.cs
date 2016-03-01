using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.Editor
{
    public class RouteConfiguration
                        :   ARouteConfiguration< MaritalStatusEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "marital-status/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
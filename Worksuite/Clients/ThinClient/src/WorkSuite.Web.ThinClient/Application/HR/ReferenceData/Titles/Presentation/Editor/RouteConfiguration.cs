using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.Editor
{
    public class RouteConfiguration : ARouteConfiguration<TitleEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "title/{id}/title-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        } 
    }
}
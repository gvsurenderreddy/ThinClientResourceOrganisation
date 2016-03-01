using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.Edit
{
    public class RouteConfiguration
                    : ARouteConfiguration<BreakEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/break/{break_id}/break-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
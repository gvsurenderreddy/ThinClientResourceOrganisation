using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.EditEditor
{
    public class RouteConfiguration
                    : ARouteConfiguration<BreakTemplateDetailsEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/break-template-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
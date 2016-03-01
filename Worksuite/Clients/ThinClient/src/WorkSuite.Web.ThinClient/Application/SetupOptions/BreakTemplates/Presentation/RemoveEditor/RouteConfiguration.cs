using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.RemoveEditor
{
    public class RouteConfiguration
                    : ARouteConfiguration<RemoveBreakTemplatePresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/remove-break-template-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
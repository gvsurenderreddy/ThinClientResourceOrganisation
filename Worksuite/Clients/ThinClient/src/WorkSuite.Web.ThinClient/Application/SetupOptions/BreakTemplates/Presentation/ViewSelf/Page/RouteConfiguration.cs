using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewSelf.Page
{
    public class RouteConfiguration
                    : APageRouteConfiguration<BreakTemplateViewSelfPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/break-template-details"; }
        }
    }
}
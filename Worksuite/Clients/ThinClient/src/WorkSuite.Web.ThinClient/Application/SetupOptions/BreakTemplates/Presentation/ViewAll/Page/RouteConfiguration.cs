using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.ViewAll.Page
{
    public class RouteConfiguration
                    : APageRouteConfiguration<BreakTemplatesViewAllPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "break-templates/view"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.New.Page
{
    public class RouteConfiguration
                    : APageRouteConfiguration<NewBreakTemplatePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "break-templates/new"; }
        }
    }
}
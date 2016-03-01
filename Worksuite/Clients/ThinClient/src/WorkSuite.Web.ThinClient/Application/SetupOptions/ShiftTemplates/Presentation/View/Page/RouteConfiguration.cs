using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.View.Page
{
    public class RouteConfiguration
                     : APageRouteConfiguration<ViewShiftTemplatesPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "shift-templates/view"; }
        }
    }
}
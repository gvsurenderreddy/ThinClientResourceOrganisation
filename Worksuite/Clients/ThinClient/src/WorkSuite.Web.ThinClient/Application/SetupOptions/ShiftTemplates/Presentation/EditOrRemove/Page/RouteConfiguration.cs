using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.Page
{
    public class RouteConfiguration
                   : APageRouteConfiguration<EditShiftTemplatePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "shift-template/{shift_template_id}/Edit"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.Remove
{
    public class RouteConfiguration
                     : ARouteConfiguration<RemoveShiftTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "shift-template/{shift_template_id}/remove-shift-template-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
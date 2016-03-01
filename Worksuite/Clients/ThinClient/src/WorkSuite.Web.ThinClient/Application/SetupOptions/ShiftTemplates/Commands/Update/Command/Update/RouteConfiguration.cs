using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.Update.Command.Update
{
    public class RouteConfiguration
                   : ARouteConfiguration<UpdateShifteTemplateDetailsController>
    {
        public override string id
        {
            get { return Resource.id; }
        }

        public override string url
        {
            get { return "shift-template/{shift_template_id}/update-shift-template-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
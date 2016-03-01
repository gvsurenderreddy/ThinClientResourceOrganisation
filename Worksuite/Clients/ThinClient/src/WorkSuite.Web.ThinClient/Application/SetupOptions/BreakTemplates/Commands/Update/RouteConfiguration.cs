using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Update
{
    public class RouteConfiguration
                    : ARouteConfiguration<UpdateBreakTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/update-break-template-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Remove
{
    public class RouteConfiguration
                    : ARouteConfiguration<RemoveBreakTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/remove-break-template-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
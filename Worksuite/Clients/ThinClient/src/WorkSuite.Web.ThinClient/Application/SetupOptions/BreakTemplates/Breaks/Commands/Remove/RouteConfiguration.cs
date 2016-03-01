using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Commands.Remove
{
    public class RouteConfiguration
                    : ARouteConfiguration<RemoveBreakController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/break/{break_id}/remove-break"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
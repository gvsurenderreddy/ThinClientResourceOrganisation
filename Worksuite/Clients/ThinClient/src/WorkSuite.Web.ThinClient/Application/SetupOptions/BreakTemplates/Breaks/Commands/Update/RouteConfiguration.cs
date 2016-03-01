using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Commands.Update
{
    public class RouteConfiguration
                    : ARouteConfiguration<UpdateBreakController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-template/{template_id}/break/{break_id}/update-break-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
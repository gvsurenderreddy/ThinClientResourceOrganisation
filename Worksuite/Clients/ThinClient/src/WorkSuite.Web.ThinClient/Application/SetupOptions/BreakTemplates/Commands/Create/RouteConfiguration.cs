using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Commands.Create
{
    public class RouteConfiguration
                    : ARouteConfiguration<CreateBreakTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "break-templates/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
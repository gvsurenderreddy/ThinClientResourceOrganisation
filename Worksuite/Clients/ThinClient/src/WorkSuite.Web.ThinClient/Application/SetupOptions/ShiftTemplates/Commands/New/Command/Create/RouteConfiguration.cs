using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Commands.New.Command.Create
{
    public class RouteConfiguration
                    : ARouteConfiguration<CreateShiftTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "shift-templates/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
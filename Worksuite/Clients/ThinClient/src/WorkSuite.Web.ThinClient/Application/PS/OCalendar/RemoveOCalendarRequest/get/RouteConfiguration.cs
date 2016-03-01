using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Remove.Presentation.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveOperationsCalendarPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/remove-operations-calendar-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
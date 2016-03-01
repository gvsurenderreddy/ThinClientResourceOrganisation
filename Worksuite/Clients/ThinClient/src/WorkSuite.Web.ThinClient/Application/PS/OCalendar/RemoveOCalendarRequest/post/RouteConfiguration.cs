using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Remove.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveOperationsCalendarController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/remove-operations-calendar-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
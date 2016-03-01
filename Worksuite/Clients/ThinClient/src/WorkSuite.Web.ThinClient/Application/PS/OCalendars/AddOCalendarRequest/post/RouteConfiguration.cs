using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.New.Commands.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration< CreateOperationsCalendarController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendars/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
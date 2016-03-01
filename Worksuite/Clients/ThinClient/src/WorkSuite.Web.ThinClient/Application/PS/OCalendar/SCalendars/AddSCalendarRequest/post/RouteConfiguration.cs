using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Commands.New.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration<CreateShiftCalendarController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendars/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
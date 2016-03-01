using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Commands.Publish
{
    public class RouteConfiguration
                        : ARouteConfiguration<PublishShiftCalendarController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/publish-shift-calendar-details/new/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
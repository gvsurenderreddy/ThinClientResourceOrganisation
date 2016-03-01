using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration<RemoveShiftCalendarController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/remove-shift-calendar-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
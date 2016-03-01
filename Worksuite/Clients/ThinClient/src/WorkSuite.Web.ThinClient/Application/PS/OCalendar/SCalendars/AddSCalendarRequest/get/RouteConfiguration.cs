using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.New.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration<NewShiftCalendarPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendars/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
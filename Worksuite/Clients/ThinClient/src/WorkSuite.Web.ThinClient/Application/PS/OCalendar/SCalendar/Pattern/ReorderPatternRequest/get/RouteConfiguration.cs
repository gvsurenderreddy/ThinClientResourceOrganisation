using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.reorderPattern.get
{
    public class RouteConfiguration
                        : ARouteConfiguration< ReorderPatternPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/shift-calendar-pattern-details-reorder-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
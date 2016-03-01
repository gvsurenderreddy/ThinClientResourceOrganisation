using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.New.Presentation.Page
{
    public class RouteConfiguration
                      : APageRouteConfiguration<NewShiftOccurrencePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/start-date/{start_date}/add-new-shift/new"; }
        }
    }
}
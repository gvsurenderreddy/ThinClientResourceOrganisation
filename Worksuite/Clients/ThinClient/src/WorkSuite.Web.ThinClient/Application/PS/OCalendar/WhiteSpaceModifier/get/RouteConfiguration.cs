using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.WhiteSpaceTimeAllocationPalette
{
    public class RouteConfiguration : APageRouteConfiguration<WhiteSpaceTimeAllocationPalettePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "operational-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/white-space-time-allocation-palette/start-date={start_date}"; }
        }
    }
}
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangePalette.Component
{
    public class RouteConfiguration : APageRouteConfiguration<DateRangePalettePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "operational-calendar/date-range-palette"; }
        }
    }
}
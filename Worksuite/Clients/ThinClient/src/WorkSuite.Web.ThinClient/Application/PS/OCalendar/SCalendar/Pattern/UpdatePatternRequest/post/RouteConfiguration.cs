using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.updatePattern.post
{
    public class RouteConfiguration
                        : ARouteConfiguration<UpdatePatternController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/update-shift-calendar-pattern-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
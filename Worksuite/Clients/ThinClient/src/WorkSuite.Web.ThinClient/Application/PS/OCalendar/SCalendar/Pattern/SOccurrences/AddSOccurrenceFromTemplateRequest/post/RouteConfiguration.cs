using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Commands.CreateFromShiftTemplate
{
    public class RouteConfiguration : ARouteConfiguration<CreateShiftOccurrenceFromShiftTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-patterns/{shift_calendar_pattern_id}/shift-occurrences/new-from-template/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
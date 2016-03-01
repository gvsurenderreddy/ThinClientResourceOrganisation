using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Commands.Edit
{
    public class RouteConfiguration : ARouteConfiguration<EditShiftBreakController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-patterns/{shift_calendar_pattern_id}/shift-occurrence/{shift_occurrence_id}/shift-break/{shift_break_id}/edit-shift-break/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
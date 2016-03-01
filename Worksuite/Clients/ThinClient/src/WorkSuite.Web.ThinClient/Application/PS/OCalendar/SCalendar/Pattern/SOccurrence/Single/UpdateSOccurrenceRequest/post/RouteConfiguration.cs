using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.Edit.Command.Update
{
    public class RouteConfiguration
                   : ARouteConfiguration<EditSingleShiftOccurrenceController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get
            {
                return "operations-calendars/{operations_calendar_id}/shift-calendars/{shift_calendar_id}/shift-calendar-patterns/{shift_calendar_pattern_id}/shift-occurrences/{shift_occurrence_id}/edit-single";
            }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}
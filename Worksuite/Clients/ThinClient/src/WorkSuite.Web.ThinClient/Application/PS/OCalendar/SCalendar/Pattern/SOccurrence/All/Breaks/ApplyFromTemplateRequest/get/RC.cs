using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.TemplateEditor
{
    public class RouteConfiguration : ARouteConfiguration<ApplyShiftBreaksFromBreakTemplateForAllOccurrencesEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/shift-occurrence/{shift_occurrence_id}/apply-breaks-from-template-for-all-occurrences-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.reorderPattern.get
{
    public class ReorderShiftCalendarPatternDetailsDisplay : ReorderShiftCalendarPatternDetails
    {
        //This is required to get ordering of fields right in the display of the editor.
        public new string shift_calendar_pattern_name { get; set; }
        public string actual_resource_allocated_against_requested { get; set; }
    }
}
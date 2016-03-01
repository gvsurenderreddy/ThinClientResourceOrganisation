
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.listReport
{
    public class ShiftCalendarPatternListReportDetails : ShiftCalendarPatternDetails
    {
        //This is required to get ordering of fields right in the display of the report.
        new public string shift_calendar_pattern_name { get; set; }

        public string actual_resource_allocated_against_requested { get; set; }
    }
}
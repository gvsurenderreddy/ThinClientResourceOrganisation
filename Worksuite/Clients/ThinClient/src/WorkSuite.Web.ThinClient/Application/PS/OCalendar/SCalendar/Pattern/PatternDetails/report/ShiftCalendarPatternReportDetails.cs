
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.viewPatterns.report
{
    public class ShiftCalendarPatternReportDetails : ShiftCalendarPatternIdentity
    {
        public string shift_calendar_pattern_name { get; set; }

        public string actual_resource_allocated_against_requested { get; set; }
    }
}
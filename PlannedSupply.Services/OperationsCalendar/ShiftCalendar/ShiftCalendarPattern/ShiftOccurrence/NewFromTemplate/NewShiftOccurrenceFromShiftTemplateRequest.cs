using System;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate
{
    public class NewShiftOccurrenceFromShiftTemplateRequest : TimeBlockIdentity
    {
        public int shift_template_id { get; set; }
    }
}

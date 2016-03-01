using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence
{
    public class ShiftOccurrenceDetails : ShiftOccurrenceIdentity
    {
        public string shift_title { get; set; }
        public TimePeriod time_period { get; set; }
        public IEnumerable<ShiftBreakDetails> breaks { get; set; }
    }
}

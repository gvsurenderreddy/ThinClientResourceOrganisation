
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks
{
    public class ShiftBreakDetails : ShiftBreakIdentity, ITimeAllocationBreak
    {
        public DurationRequest offset_from_start_time { get; set; }

        public DurationRequest duration { get; set; }

        public bool is_paid { get; set; }

        public int position { get; set; }
    }
}

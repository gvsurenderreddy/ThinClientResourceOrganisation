using System;
using WTS.WorkSuite.Library.DomainTypes;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence
{
    public class TimeAllocationOccurrenceDetails : ITimeAllocationOccurrence
    {
        public DateTime start_date { get; set; }

        public int  duration_in_seconds { get; set; }

        public string title { get; set; }

        public int start_time_in_seconds_from_midnight { get; set; }

        public string colour { get; set; }

        public TimeAllocationKind time_allocation_kind { get; set; }
    }

    public enum TimeAllocationKind
    {
        BREAK,
        SHIFT,
        HOLIDAY
    }

}

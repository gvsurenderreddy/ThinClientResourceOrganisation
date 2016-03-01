using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder
{
    public class ReorderShiftCalendarPatternDetails : ReorderShiftCalendarPatternRequest, IShiftPattern
    {
        public string shift_calendar_pattern_name { get; set; }

        public int number_of_resources { get; set; }

        public int resource_allocation_summary { get; set; }

        public IEnumerable<ITimeAllocationOccurrence> time_allocation_occurrences { get; set; }

        public DateTime start_date { get; set; }

        public int current_priority { get; set; }
    }
}
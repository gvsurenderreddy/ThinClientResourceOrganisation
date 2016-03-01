using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.Library.DomainTypes
{
    public interface IShiftPattern
    {
        int operations_calendar_id { get; set; }
        
        int shift_calendar_id { get; set; }

        int shift_calendar_pattern_id { get; set; }

        string shift_calendar_pattern_name { get; set; }

        int number_of_resources { get; set; }

        int resource_allocation_summary { get; set; }

      IEnumerable<ITimeAllocationOccurrence> time_allocation_occurrences { get; set; }
    }

    public interface ITimeAllocationOccurrence
    {
        DateTime start_date { get; set; }
        string title { get; set; }
        int start_time_in_seconds_from_midnight { get; set; }
        int duration_in_seconds { get; set; }
        string colour { get; set; }
    }

    public interface ITimeAllocationBreak
    {
        DurationRequest offset_from_start_time { get; set; }

        DurationRequest duration { get; set; }

        bool is_paid { get; set; }

        int position { get; set; }
    }
}

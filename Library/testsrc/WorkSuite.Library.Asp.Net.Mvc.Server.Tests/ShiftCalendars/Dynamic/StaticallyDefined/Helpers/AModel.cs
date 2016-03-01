using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.ShiftCalendars.Dynamic.StaticallyDefined.Helpers
{
    public class AModel
    {
        public string a_title;
        public string a_class;
        public string a_name;
        public string a_url;
        public string a_route_id;
        public DateTime a_start_date;
        public ShiftCalendarRange the_range_returned;
        public IEnumerable<IShiftPattern> a_collection_of_shift_patterns;
    }

    public class AShiftPattern : IShiftPattern
    {
        public int operations_calendar_id { get; set; }

        public int shift_calendar_id { get; set; }

        public int shift_calendar_pattern_id { get; set; }

        public DateTime start_date { get; set; }

        public string shift_calendar_pattern_name { get; set; }

        public int number_of_resources { get; set; }

        public int resource_allocation_summary { get; set; }

        public IEnumerable<ITimeAllocationOccurrence> time_allocation_occurrences { get; set; }
    }

    public class ATimeAllocationOccurrence : ITimeAllocationOccurrence
    {
        public DateTime start_date { get; set; }

        public string title { get; set; }

        public int start_time_in_seconds_from_midnight { get; set; }

        public int duration_in_seconds { get; set; }

        public string colour { get; set; }
    }
}
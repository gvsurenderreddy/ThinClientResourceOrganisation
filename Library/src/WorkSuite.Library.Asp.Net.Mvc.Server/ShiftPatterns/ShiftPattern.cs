using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns
{

    public class ShiftPattern : IsAViewElement
    {
        public int operations_calendar_id { get; set; }

        public int shift_calendar_id { get; set; }

        public int shift_calendar_pattern_id { get; set; }

        public string name { get; set; }

        public int number_of_resources { get; set; }

        public string resource_allocation_actual_against_projected { get; set; }

        public string previous_occurrence_colour { get; set; }

        public IEnumerable<TimeBlock> time_blocks { get; set; }
        
        public string next_occurrence_colour { get; set; }
    }

    public class TimeBlock : IsAViewElement
    {
        public DateTime date { get; set; }

        public string content_description { get; set; }

        public string content_rgb_colour { get; set; }

        public string content_type { get; set; }

        public IEnumerable<TimeSegment> time_segments { get; set; }
    }

    public class TimeSegment : IsAViewElement
    {
        public double percentage_of_day { get; set; }

        public string type { get; set; }
    }


}

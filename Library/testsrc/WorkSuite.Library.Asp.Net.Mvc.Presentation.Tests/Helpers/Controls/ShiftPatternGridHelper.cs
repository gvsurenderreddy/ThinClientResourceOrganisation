
using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls
{
    public class ShiftPatternGridHelper
    {
        public static ShiftPatternGrid create_shift_pattern_grid()
        {
            return new ShiftPatternGrid()
            {
                days = get_days(DateTime.Now.Date),
                shift_patterns = get_shift_patterns(DateTime.Now.Date),
            };
        }

        private static IEnumerable<DateTime> get_days(DateTime start_date)
        {
            var days = new List<DateTime>();

            for (var i = 0; i < 7; i++)
            {
                days.Add(start_date.AddDays(i));
            }

            return days;
        }

        private static IEnumerable<TimeBlock> get_day_blocks(DateTime the_start_date)
        {
            var days = new List<TimeBlock>();

            for (var i = 0; i < 7; i++)
            {
                days.Add(new TimeBlock()
                {
                    date = the_start_date.AddDays(i),
                    content_description = "",
                    content_rgb_colour = "",
                    time_segments = Enumerable.Empty<TimeSegment>()
                });
            }

            return days;
        }

        private static IEnumerable<ShiftPattern> get_shift_patterns(DateTime start_date)
        {
            var days = get_day_blocks(start_date);

            var shift_patterns = new List<ShiftPattern>()
            {
                new ShiftPattern()
                {
                    time_blocks = days,
                    name = "Shift Pattern A",
                    number_of_resources = 4
                },
                new ShiftPattern()
                {
                    time_blocks = days,
                    name = "Shift Pattern B",
                    number_of_resources = 7
                }
            };

            return shift_patterns;
        }

    }
}
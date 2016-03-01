using System;
using System.Linq;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Formating;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns.Dynamic
{
    public class ShiftPatternGridViewModelBuilder
    {
        private int number_of_days_range;

        private int transform_range_type_to_number_of_days(ShiftCalendarRange oc)
        {
            switch (oc)
            {
                case ShiftCalendarRange.Week:
                    return 7;
                case ShiftCalendarRange.FourWeek:
                    return 28;
                default:
                    return 7;
            }
        }

        public ShiftPatternGrid build(DateTime the_start_date, ShiftCalendarRange range, IEnumerable<IShiftPattern> the_shift_patterns)
        {
            Guard.IsNotNull(the_shift_patterns, "the_shift_patterns");

            number_of_days_range = transform_range_type_to_number_of_days(range);

            return new ShiftPatternGrid()
            {
                grid_classes = range == ShiftCalendarRange.FourWeek ? "shift-calendar-28day" : "",
                days = get_days(the_start_date),
                shift_patterns = get_shift_patterns(the_start_date, the_shift_patterns),
            };
        }

        private IEnumerable<DateTime> get_days(DateTime the_start_date)
        {
            var days = new List<DateTime>();

            for (var i = 0; i < number_of_days_range; i++)
            {
                days.Add(the_start_date.AddDays(i));
            }

            return days;
        }

        private string get_next_if_any_colour(DateTime start_date, IEnumerable<ITimeAllocationOccurrence> occurrences)
        {
            var occurrence = occurrences.LastOrDefault();
            return occurrence != null && occurrence.start_date.Date == start_date.AddDays(number_of_days_range).Date ? occurrence.colour : "";
        }

        private string get_previous_if_any_colour(DateTime start_date, IEnumerable<ITimeAllocationOccurrence> occurrences)
        {
            var occurrence = occurrences.FirstOrDefault();
            return occurrence != null && occurrence.start_date.Date == start_date.AddDays(-1).Date ? occurrence.colour : "";
        }

        private IEnumerable<TimeBlock> get_time_blocks(DateTime the_start_date, IEnumerable<ITimeAllocationOccurrence> occurrences)
        {

            var time_blocks = new List<TimeBlock>();

            for (var i = 0; i < number_of_days_range; i++)
            {
                var loop_date = the_start_date.AddDays(i);

                var occurrence = occurrences.SingleOrDefault(oc => oc.start_date.Date == loop_date.Date);

                if (occurrence != null)
                {
                    time_blocks.Add(new TimeBlock()
                    {
                        date = occurrence.start_date,
                        content_description = occurrence.title,
                        content_rgb_colour = occurrence.colour,
                        content_type = "shift",
                        time_segments = get_time_segments(occurrence, occurrences.SingleOrDefault(oc => oc.start_date.Date == loop_date.AddDays(-1).Date))
                    });
                }
                else
                {
                    time_blocks.Add(new TimeBlock()
                    {
                        date = loop_date,
                        content_description = "",
                        content_rgb_colour = "",
                        content_type = "white_space",
                        time_segments = get_block_segments(occurrences.SingleOrDefault(oc => oc.start_date.Date == loop_date.AddDays(-1).Date))
                    });
                }


            }

            return time_blocks;
        }

        private IEnumerable<TimeSegment> get_block_segments(ITimeAllocationOccurrence the_previous_occurrence)
        {
            var time_segments = new List<TimeSegment>();

            if (the_previous_occurrence != null)
            {
                var previous_occurrence_offset_percentage = get_previous_occurrence_offset_percentage(the_previous_occurrence);

                if (previous_occurrence_offset_percentage > 0)
                {
                    time_segments.Add(new TimeSegment()
                    {
                        percentage_of_day = previous_occurrence_offset_percentage,
                        type = "workingtime"
                    });
                }
            }

            return time_segments;
        }

        private IEnumerable<TimeSegment> get_time_segments(ITimeAllocationOccurrence the_occurrence, ITimeAllocationOccurrence the_previous_occurrence)
        {
            var time_segments = new List<TimeSegment>();

            var previous_occurrence_offset_percentage = get_previous_occurrence_offset_percentage(the_previous_occurrence);

            if (previous_occurrence_offset_percentage > 0)
            {
                time_segments.Add(new TimeSegment()
                {
                    percentage_of_day = previous_occurrence_offset_percentage,
                    type = "workingtime"
                });
            }

            time_segments.Add(new TimeSegment()
            {

                percentage_of_day = ((the_occurrence.start_time_in_seconds_from_midnight / 86400.0) * 100.0) - previous_occurrence_offset_percentage,
                type = "rest"
            });

            time_segments.Add(new TimeSegment()
            {
                percentage_of_day = get_occurrence_percentage(the_occurrence),
                type = "workingtime"
            });

            return time_segments;
        }

        private double get_occurrence_percentage(ITimeAllocationOccurrence the_occurrence)
        {
            if (crosses_day(the_occurrence))
            {
                return ((86400 - the_occurrence.start_time_in_seconds_from_midnight) / 86400.0) * 100.0;
            }

            return (the_occurrence.duration_in_seconds / 86400.0) * 100.0;
        }

        private double get_previous_occurrence_offset_percentage(ITimeAllocationOccurrence the_previous_occurrence)
        {
            int offset = 0;

            if (crosses_day(the_previous_occurrence))
            {
                offset = get_offset(the_previous_occurrence).number_of_seconds_after_midnight;
            }

            return (offset / 86400.0) * 100.0;
        }

        private bool crosses_day(ITimeAllocationOccurrence the_occurrence)
        {
            return the_occurrence != null && (the_occurrence.start_time_in_seconds_from_midnight + the_occurrence.duration_in_seconds) > 86400;
        }

        private Offset get_offset(ITimeAllocationOccurrence the_occurrence)
        {
            Guard.IsNotNull(the_occurrence, "the_occurrence");

            return new Offset()
            {
                number_of_seconds_before_midnight = 86400 - the_occurrence.start_time_in_seconds_from_midnight,
                number_of_seconds_after_midnight = (the_occurrence.start_time_in_seconds_from_midnight + the_occurrence.duration_in_seconds) - 86400
            };
        }


        private IEnumerable<ShiftPattern> get_shift_patterns(DateTime the_start_date, IEnumerable<IShiftPattern> patterns)
        {
            return patterns.Select(p => new ShiftPattern()
            {
                previous_occurrence_colour = get_previous_if_any_colour(the_start_date, p.time_allocation_occurrences),
                next_occurrence_colour = get_next_if_any_colour(the_start_date, p.time_allocation_occurrences),
                operations_calendar_id = p.operations_calendar_id,
                shift_calendar_id = p.shift_calendar_id,
                shift_calendar_pattern_id = p.shift_calendar_pattern_id,
                time_blocks = get_time_blocks(the_start_date, p.time_allocation_occurrences),
                name = p.shift_calendar_pattern_name,
                number_of_resources = p.number_of_resources,
                resource_allocation_actual_against_projected = ReportFormatStringExtension.actual_against_requested_string_for_resource_allocation(p.resource_allocation_summary, p.number_of_resources)
            });
        }

        private struct Offset
        {
            public int number_of_seconds_before_midnight { get; set; }

            public int number_of_seconds_after_midnight { get; set; }
        }
    }
}

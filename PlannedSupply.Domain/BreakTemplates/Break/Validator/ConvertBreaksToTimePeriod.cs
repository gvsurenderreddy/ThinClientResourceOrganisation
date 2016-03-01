using System;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator
{
    public static class ConvertBreaksToTimePeriod
    {
        public static TimePeriod to_time_period(this Breaks.Break breaks)
        {
            var date_time = new DateTime();
            var offset_to_date_time = date_time.AddSeconds(breaks.offset_from_start_time_in_seconds);
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                breaks.duration_in_seconds);

        }
    }
}
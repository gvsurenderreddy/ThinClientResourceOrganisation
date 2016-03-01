using System;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods
{
    public static class ConvertEndTimeToSeconds
    {
        
        public static int end_time_in_seconds
                                             (this TimeRequest value)
        {
            var time_in_seconds = Convert.ToInt32(value.hours) * 60 * 60 + Convert.ToInt32(value.minutes) * 60;
            return time_in_seconds;
        }
    }
}
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods
{
    public class TimePeriod
    {
        public UtcTime start_at { get; private set; }
        public int duration { get; private set; }

        public TimePeriod
                ( UtcTime start_at
                , int duration )
        {

            this.start_at = start_at;
            this.duration = duration;
        }
    }

    public static class TimePeriodExtension
    {
        public static UtcTime calculate_end_time(this TimePeriod time_period)
        {
            return time_period.start_at.end_time_utc_format(time_period.duration)
                   .end_time_presentation_format();
        }
    }
}
using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Clocks {

    /// <summary>
    ///     Represents a utc time
    /// </summary>
    public class UtcTime {

        public int year { get; private set; }
        public int month { get; private set; }
        public int day { get; private set; }
        public int hours { get; private set; }
        public int minutes { get; private set; }
        public int seconds { get; private set; }
        public int milliseconds { get; private set; }

        public UtcTime
                ( int year
                , int month
                , int day
                , int hours
                , int minutes
                , int seconds
                , int milliseconds ){

            this.year = year;
            this.month = month;
            this.day = day;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }
    }

    public static class UtcTimeExtensions {

        public static DateTime ToDateTime
                                ( this UtcTime time ) {

            Guard.IsNotNull( time, "time" );

            return new DateTime(
                year: time.year,
                month: time.month,
                day: time.day,

                hour: time.hours,
                minute: time.minutes, 
                second: time.seconds,
                millisecond: time.milliseconds,
                kind: DateTimeKind.Utc
            );

        }
        
    }

    public static class ValidateUtcTimeAtTwentyFourHour
    {
        public static UtcTime end_time_utc_format(this UtcTime start_at, int duration)
        {
            start_at_hour = start_at.hours;
            var start_date= start_at.hours >= 24 ?new UtcTime(start_at.year,start_at.month,start_at.day  , 0,start_at.minutes,start_at.seconds,start_at.milliseconds) : start_at ;
            var time_period_duration = start_date.ToDateTime().AddSeconds(duration);

            return end_time_in_utc_format = new UtcTime ( time_period_duration.Year
                                                        , time_period_duration.Month
                                                        , time_period_duration.Day
                                                        , time_period_duration.Hour
                                                        , time_period_duration.Minute
                                                        , time_period_duration.Second
                                                        , time_period_duration.Millisecond);
                                                                          
        }

        /// <summary>
        ///  end time has the utc format and as far as we know UTC format does not have 24 hour .
        ///  in the presentation layer we need to show 24 hour instead of 0 hour .
        ///  So end_time_presentation_format convert 0 hour to 24 for end time .
        /// </summary>
        /// <param name="start_at"></param>
        /// <returns></returns>
        public static UtcTime end_time_presentation_format(this UtcTime start_at)
        {

            var hours = (end_time_in_utc_format.hours == 0 && start_at_hour != 24 && end_time_in_utc_format.minutes == 0) ? 24 : end_time_in_utc_format.hours;

            if (end_time_in_utc_format.hours != 0) return new UtcTime ( end_time_in_utc_format.year
                                                                      , end_time_in_utc_format.month
                                                                      , end_time_in_utc_format.day
                                                                      , end_time_in_utc_format.hours
                                                                      , end_time_in_utc_format.minutes
                                                                      , end_time_in_utc_format.seconds
                                                                      , end_time_in_utc_format.milliseconds);
            var end_date = new UtcTime ( end_time_in_utc_format.year
                                       , end_time_in_utc_format.month
                                       , end_time_in_utc_format.day
                                       , hours
                                       , end_time_in_utc_format.minutes
                                       , end_time_in_utc_format.seconds
                                       , end_time_in_utc_format.milliseconds);
            return end_date;
        }
        
        public static UtcTime end_time_in_utc_format;
        public static int start_at_hour;
    }
}

